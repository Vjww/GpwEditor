using Data.Enums;
using System;
using System.IO;
using System.Text;

namespace Data.FileConnection
{
    public class TextFileConnectionBase : IFileConnection
    {
        protected StreamReader StreamReader;
        protected StreamWriter StreamWriter;
        protected StreamDirectionType? StreamDirection;

        public void Open(string filePath, StreamDirectionType streamDirection)
        {
            FileStream fileStream = null;
            StreamDirection = streamDirection;

            // Open a stream for reading or writing
            try
            {
                switch (StreamDirection)
                {
                    case StreamDirectionType.Read:
                        fileStream = File.Open(filePath, FileMode.Open);
                        StreamReader = new StreamReader(fileStream, Encoding.Default, false);
                        break;
                    case StreamDirectionType.Write:
                        fileStream = File.Open(filePath, FileMode.Open);
                        StreamWriter = new StreamWriter(fileStream, Encoding.Default);
                        break;
                    default:
                        throw new NotImplementedException("Case not implemented in switch statement.");
                }
            }
            catch (Exception)
            {
                // Close streams
                if (StreamReader != null)
                {
                    StreamReader.Close();
                    StreamReader = null;
                }

                if (StreamWriter != null)
                {
                    StreamWriter.Close();
                    StreamWriter = null;
                }

                // Close underlying stream
                if (fileStream != null)
                {
                    fileStream.Close();
                }

                throw;
            }
        }

        public void Close()
        {
            // Close streams
            if (StreamReader != null)
            {
                StreamReader.Close();
                StreamReader = null;
            }

            if (StreamWriter != null)
            {
                StreamWriter.Close();
                StreamWriter = null;
            }

            // Clear stream direction
            StreamDirection = null;
        }
    }
}
