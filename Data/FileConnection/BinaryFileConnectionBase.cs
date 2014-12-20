using Data.Enums;
using System;
using System.IO;

namespace Data.FileConnection
{
    public class BinaryFileConnectionBase : IFileConnection
    {
        private BinaryReader _binaryReader;
        private BinaryWriter _binaryWriter;
        private StreamDirectionType? _streamDirection;

        public void Open(string filePath, StreamDirectionType streamDirection)
        {
            FileStream fileStream = null;
            _streamDirection = streamDirection;

            // Open a stream for reading or writing
            try
            {
                switch (_streamDirection)
                {
                    case StreamDirectionType.Read:
                        fileStream = File.Open(filePath, FileMode.Open);
                        _binaryReader = new BinaryReader(fileStream);
                        break;
                    case StreamDirectionType.Write:
                        fileStream = File.Open(filePath, FileMode.Open);
                        _binaryWriter = new BinaryWriter(fileStream);
                        break;
                    default:
                        throw new NotImplementedException("Case not implemented in switch statement.");
                }
            }
            catch (Exception)
            {
                // Close streams
                if (_binaryReader != null)
                {
                    _binaryReader.Close();
                    _binaryReader = null;
                }

                if (_binaryWriter != null)
                {
                    _binaryWriter.Close();
                    _binaryWriter = null;
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
            if (_binaryReader != null)
            {
                _binaryReader.Close();
                _binaryReader = null;
            }

            if (_binaryWriter != null)
            {
                _binaryWriter.Close();
                _binaryWriter = null;
            }

            // Clear stream direction
            _streamDirection = null;
        }

        public byte ReadByte(long position)
        {
            if (_streamDirection != StreamDirectionType.Read)
                throw new Exception("Stream direction must be read.");

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadByte();
        }

        public byte[] ReadByteArray(long position, int count)
        {
            if (_streamDirection != StreamDirectionType.Read)
                throw new Exception("Stream direction must be read.");

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadBytes(count);
        }

        public int ReadInteger(long position)
        {
            if (_streamDirection != StreamDirectionType.Read)
                throw new Exception("Stream direction must be read.");

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadInt32();
        }

        public void WriteByte(long filePosition, byte value)
        {
            if (_streamDirection != StreamDirectionType.Write)
                throw new Exception("Stream direction must be write.");

            _binaryWriter.BaseStream.Seek(filePosition, SeekOrigin.Begin);
            _binaryWriter.Write(value);
        }

        public void WriteByteArray(long filePosition, byte[] value)
        {
            if (_streamDirection != StreamDirectionType.Write)
                throw new Exception("Stream direction must be write.");

            _binaryWriter.BaseStream.Seek(filePosition, SeekOrigin.Begin);
            _binaryWriter.Write(value);
        }

        public void WriteInteger(long filePosition, int value)
        {
            if (_streamDirection != StreamDirectionType.Write)
                throw new Exception("Stream direction must be write.");

            _binaryWriter.BaseStream.Seek(filePosition, SeekOrigin.Begin);
            _binaryWriter.Write(value);
        }
    }
}
