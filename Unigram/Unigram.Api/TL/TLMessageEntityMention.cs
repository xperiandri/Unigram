// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLMessageEntityMention : TLMessageEntityBase 
	{

		public TLMessageEntityMention() { }
		public TLMessageEntityMention(TLBinaryReader from, TLType type = TLType.MessageEntityMention)
		{
			Read(from, type);
		}

		public override TLType TypeId { get { return TLType.MessageEntityMention; } }

		public override void Read(TLBinaryReader from, TLType type = TLType.MessageEntityMention)
		{
			Offset = from.ReadInt32();
			Length = from.ReadInt32();
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0xFA04579D);
			to.Write(Offset);
			to.Write(Length);
		}
	}
}