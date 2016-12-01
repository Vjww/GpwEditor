using System;
using Common.Enums;
using Common.FileConnection;

namespace Data.FileConnection
{
    public class ExecutableConnection : BinaryFileConnectionBase
    {
        public ExecutableConnection(string filePath) : base(filePath)
        {
            //
        }

        public override byte ReadByte(long position)
        {
            if (!IsRead())
            {
                SwitchStreamDirection();
            }

            return base.ReadByte(position);
        }

        public override byte[] ReadByteArray(long position, int count)
        {
            if (!IsRead())
            {
                SwitchStreamDirection();
            }

            return base.ReadByteArray(position, count);
        }

        public override int ReadInteger(long position)
        {
            if (!IsRead())
            {
                SwitchStreamDirection();
            }

            return base.ReadInteger(position);
        }

        public override void WriteByte(long position, byte value)
        {
            if (!IsWrite())
            {
                SwitchStreamDirection();
            }

            base.WriteByte(position, value);
        }

        public override void WriteByteArray(long position, byte[] value)
        {
            if (!IsWrite())
            {
                SwitchStreamDirection();
            }

            base.WriteByteArray(position, value);
        }

        public override void WriteInteger(long position, int value)
        {
            if (!IsWrite())
            {
                SwitchStreamDirection();
            }

            base.WriteInteger(position, value);
        }

        private void SwitchStreamDirection()
        {
            // Switch read to write
            if (IsRead())
            {
                Close();
                Open(StreamDirectionType.Write);
                return;
            }

            // Switch write to read
            if (IsWrite())
            {
                Close();
                Open(StreamDirectionType.Read);
                return;
            }

            throw new Exception("Unable to switch stream direction, as stream direction not defined.");
        }

        private bool IsRead()
        {
            return StreamDirection == StreamDirectionType.Read;
        }

        private bool IsWrite()
        {
            return StreamDirection == StreamDirectionType.Write;
        }
    }
}
