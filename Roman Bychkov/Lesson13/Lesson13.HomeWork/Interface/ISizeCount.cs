internal interface ISizeCount
{
    public ushort Count(byte size = 1);
    public  bool AddCountToSize(ushort count, byte size = 1);
    public  bool DeleteCountFromSize(ushort count, byte size = 1);
}

