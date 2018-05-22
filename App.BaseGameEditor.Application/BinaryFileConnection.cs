using System;
using System.IO;

namespace App.BaseGameEditor.Application
{
    public class BinaryFileConnectionBase : IDisposable
    {
        private BinaryReader _binaryReader;
        private BinaryWriter _binaryWriter;
        protected StreamDirectionType? StreamDirection;
        protected string FilePath;

        protected BinaryFileConnectionBase(string filePath)
        {
            FilePath = filePath;

            Open(StreamDirectionType.Read);
        }

        public void Dispose()
        {
            Close();
        }

        protected void Open(StreamDirectionType streamDirection)
        {
            StreamDirection = streamDirection;

            // Open a stream for reading or writing
            FileStream fileStream = null;
            try
            {
                switch (StreamDirection)
                {
                    case StreamDirectionType.Read:
                        fileStream = File.Open(FilePath, FileMode.Open);
                        _binaryReader = new BinaryReader(fileStream);
                        break;
                    case StreamDirectionType.Write:
                        fileStream = File.Open(FilePath, FileMode.Open);
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

                // Close underlying stream if not already closed
                fileStream?.Close();

                throw;
            }
        }

        protected void Close()
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
            StreamDirection = null;
        }

        public virtual byte ReadByte(long position)
        {
            if (StreamDirection != StreamDirectionType.Read)
            {
                throw new Exception("Stream direction must be read.");
            }

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadByte();
        }

        public virtual byte[] ReadByteArray(long position, int count)
        {
            if (StreamDirection != StreamDirectionType.Read)
            {
                throw new Exception("Stream direction must be read.");
            }

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadBytes(count);
        }

        public virtual int ReadInteger(long position)
        {
            if (StreamDirection != StreamDirectionType.Read)
            {
                throw new Exception("Stream direction must be read.");
            }

            _binaryReader.BaseStream.Seek(position, SeekOrigin.Begin);
            return _binaryReader.ReadInt32();
        }

        public virtual void WriteByte(long position, byte value)
        {
            WriteValue(position, value);
        }

        public virtual void WriteByteArray(long position, byte[] value)
        {
            WriteValue(position, value);
        }

        public virtual void WriteInteger(long position, int value)
        {
            WriteValue(position, value);
        }

        private void WriteValue<T>(long filePosition, T value)
        {
            // Use dynamic to resolve T at runtime
            // http://stackoverflow.com/a/7148003

            dynamic dynamicValue = value;

            if (StreamDirection != StreamDirectionType.Write)
            {
                throw new Exception("Stream direction must be write.");
            }

            _binaryWriter.BaseStream.Seek(filePosition, SeekOrigin.Begin);
            _binaryWriter.Write(dynamicValue);
        }
    }
}