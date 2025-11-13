' We need these namespaces for audio playback and memory operations
Imports System.Media
Imports System.IO

Public Class Form1

    ' Class-level variable to hold our sound player.
    ' We do this so we can stop the sound later and properly manage
    ' the memory stream it's using.
    Private player As SoundPlayer = Nothing

    ''' <summary>
    ''' This event fires when the "Play" button is clicked.
    ''' </summary>
    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        ' 1. Get all the settings from the UI controls
        Dim frequency As Double = CDbl(numFrequency.Value)
        Dim durationMs As Integer = CInt(numDuration.Value)

        ' Convert the TrackBar's 0-100 value to a 0.0-1.0 amplitude scale
        Dim amplitude As Double = CDbl(trackVolume.Value) / 100.0

        ' 2. Stop and dispose of any previous sound
        ' This is important to free up the old memory stream
        If player IsNot Nothing Then
            player.Stop()
            If player.Stream IsNot Nothing Then
                player.Stream.Dispose()
            End If
            player.Dispose()
            player = Nothing
        End If

        Try
            ' 3. Generate the new sound
            ' This function (see below) creates a full WAV file in a MemoryStream
            Dim waveStream As MemoryStream = GenerateWavStream(frequency, durationMs, amplitude)

            ' 4. Play the sound
            ' We create a new SoundPlayer and give it the stream
            player = New SoundPlayer(waveStream)
            player.Play()

        Catch ex As Exception
            ' Show an error if something went wrong (e.g., invalid parameters)
            MessageBox.Show("Error generating sound: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Generates a complete 16-bit PCM mono WAV file structure into a MemoryStream.
    ''' </summary>
    ''' <param name="frequency">The frequency of the sine wave (e.g., 440.0 for A4)</param>
    ''' <param name="durationMs">The duration in milliseconds (e.g., 1000 for 1 second)</param>
    ''' <param name="amplitude">The volume, from 0.0 (silent) to 1.0 (full)</param>
    ''' <returns>A MemoryStream containing the complete WAV file data, rewinded to the beginning.</returns>
    Private Function GenerateWavStream(ByVal frequency As Double, ByVal durationMs As Integer, ByVal amplitude As Double) As MemoryStream
        ' --- Constants for the audio format ---
        Const sampleRate As Integer = 44100     ' CD quality sample rate
        Const bitsPerSample As Short = 16       ' 16-bit audio
        Const channels As Short = 1             ' 1 = Mono, 2 = Stereo
        Const bytesPerSample As Short = bitsPerSample / 8

        ' --- Calculate total data size ---
        ' Total number of samples = (duration in seconds) * (samples per second)
        Dim totalSamples As Integer = CInt(Math.Floor((durationMs / 1000.0) * sampleRate))
        ' Total size of the audio data in bytes
        Dim dataSize As Integer = totalSamples * bytesPerSample * channels

        ' This is the maximum value for a 16-bit signed short
        ' We scale this by the amplitude (volume)
        Dim maxAmplitude As Integer = CInt((32767 * amplitude))

        ' The MemoryStream will hold the entire WAV file
        ' We will use a BinaryWriter to easily write bytes and strings to it
        Dim ms As New MemoryStream()
        Dim writer As New BinaryWriter(ms)

        ' -------------------------------------------------
        ' 1. Write the "RIFF" header (12 bytes)
        ' -------------------------------------------------
        writer.Write("RIFF".ToCharArray())
        ' File size (36 bytes for headers + size of data)
        ' This is the total file size minus the first 8 bytes
        writer.Write(CInt(36 + dataSize))
        writer.Write("WAVE".ToCharArray())

        ' -------------------------------------------------
        ' 2. Write the "fmt " (format) chunk (24 bytes)
        ' -------------------------------------------------
        writer.Write("fmt ".ToCharArray())
        ' Size of this chunk (16 bytes for standard PCM)
        writer.Write(CInt(16))
        ' Audio format (1 = PCM, which is uncompressed)
        writer.Write(CShort(1))
        ' Number of channels
        writer.Write(channels)
        ' Sample Rate (e.g., 44100)
        writer.Write(sampleRate)
        ' Byte Rate (SampleRate * Channels * BytesPerSample)
        writer.Write(CInt(sampleRate * bytesPerSample * channels))
        ' Block Align (Channels * BytesPerSample)
        writer.Write(CShort(bytesPerSample * channels))
        ' Bits Per Sample
        writer.Write(bitsPerSample)

        ' -------------------------------------------------
        ' 3. Write the "data" chunk header (8 bytes)
        ' -------------------------------------------------
        writer.Write("data".ToCharArray())
        ' Size of the actual audio data
        writer.Write(dataSize)

        ' -------------------------------------------------
        ' 4. Write the actual sine wave data
        ' -------------------------------------------------
        Dim t As Double = (Math.PI * 2 * frequency) / sampleRate
        For i As Integer = 0 To totalSamples - 1
            ' Calculate the sample value
            ' This is the core sine wave formula
            Dim sampleValue As Double = maxAmplitude * Math.Sin(t * i)

            ' Write the sample as a 16-bit signed short
            writer.Write(CShort(sampleValue))
        Next

        ' --- Cleanup ---
        ' Flush the writer to ensure all data is written to the stream
        writer.Flush()
        ' Rewind the stream to the beginning (position 0)
        ' so the SoundPlayer can read it from the start.
        ms.Seek(0, SeekOrigin.Begin)

        ' Return the stream. The caller (btnPlay_Click) is responsible
        ' for disposing of this stream when it's done.
        Return ms
    End Function

    ''' <summary>
    ''' This event fires when the form is closing.
    ''' </summary>
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' This is important!
        ' We must stop and dispose of the player and its stream
        ' when the application closes, otherwise it can be left
        ' hanging in memory.
        If player IsNot Nothing Then
            player.Stop()
            If player.Stream IsNot Nothing Then
                player.Stream.Dispose()
            End If
            player.Dispose()
            player = Nothing
        End If
    End Sub

End Class