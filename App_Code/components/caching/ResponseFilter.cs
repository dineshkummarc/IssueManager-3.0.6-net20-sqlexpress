//ResponseFilter class @0-4BB82D51
//Target Framework version is 2.0
using System.IO;

namespace IssueManager.Caching
{
	public class ResponseFilter : Stream
	{
		private Stream _sink;
		private long _position;
		private MemoryStream body;

		public ResponseFilter(Stream sink)
		{
			_sink = sink;
			body = new MemoryStream();
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override long Length
		{
			get { return 0; }
		}

		public override long Position
		{
			get { return _position; }
			set { _position = value; }
		}

		public MemoryStream Body
		{
			get { return body; }
		}

		public override long Seek(long offset, SeekOrigin direction)
		{
			return _sink.Seek(offset, direction);
		}

		public override void SetLength(long length)
		{
			_sink.SetLength(length);
		}

		public override void Close()
		{
			_sink.Close();
		}

		public override void Flush()
		{
			_sink.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _sink.Read(buffer, offset, count);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			body.Write(buffer,offset,count);
			_sink.Write(buffer , offset, count);

		}

	}
}

//End ResponseFilter class

