// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLMsgNewDetailedInfo : TLMsgDetailedInfoBase 
	{
		public TLMsgNewDetailedInfo() { }
		public TLMsgNewDetailedInfo(TLBinaryReader from)
		{
			Read(from);
		}

		public override TLType TypeId { get { return TLType.MsgNewDetailedInfo; } }

		public override void Read(TLBinaryReader from)
		{
			AnswerMsgId = from.ReadInt64();
			Bytes = from.ReadInt32();
			Status = from.ReadInt32();
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0x809DB6DF);
			to.Write(AnswerMsgId);
			to.Write(Bytes);
			to.Write(Status);
		}
	}
}