class Mq4String
{
	private readonly string _value;
	
	public Mq4String(string value)
	{
		_value = value;
	}

	public static implicit operator Mq4String(string value)
	{
		return new Mq4String(value);
	}
	
	public static implicit operator Mq4String(int value)
	{
		return new Mq4String(value.ToString());
	}
		
	public static implicit operator Mq4String(Mq4Null mq4Null)
	{
		return new Mq4String(null);
	}
	
	public static implicit operator string(Mq4String mq4String)
	{
		if ((object)mq4String == null)
                return null;

		return mq4String._value;
	}
			
	public static implicit operator Mq4String(Mq4Double mq4Double)
	{
		return new Mq4String(mq4Double.ToString());
	}

	public static bool operator <(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) == -1;
	}
		
	public static bool operator >(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) == 1;
	}
	
	public static bool operator <(Mq4String x, string y)
	{
		return string.Compare(x._value, y) == -1;
	}
		
	public static bool operator >(Mq4String x, string y)
	{
		return string.Compare(x._value, y) == 1;
	}
	public static bool operator <=(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) <= 0;
	}
		
	public static bool operator >=(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) >= 0;
	}
	
	public static bool operator <=(Mq4String x, string y)
	{
		return string.Compare(x._value, y) <= 0;
	}
		
	public static bool operator >=(Mq4String x, string y)
	{
		return string.Compare(x._value, y) >= 0;
	}
			
	public static bool operator ==(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) == 0;
	}
			
	public static bool operator !=(Mq4String x, Mq4String y)
	{
		return string.Compare(x._value, y._value) != 0;
	}
				
	public static bool operator ==(Mq4String x, string y)
	{
		return string.Compare(x._value, y) == 0;
	}
			
	public static bool operator !=(Mq4String x, string y)
	{
		return string.Compare(x._value, y) != 0;
	}
		
	public override string ToString()
	{
		if ((object)this == null)
            return string.Empty;

		return _value.ToString();
	}
	
	public static readonly Mq4String Empty = new Mq4String(string.Empty);

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Mq4String) obj);
    }

	protected bool Equals(Mq4String other)
    {
        return this == other;
    }

    public override int GetHashCode()
    {
        return (_value != null ? _value.GetHashCode() : 0);
    }
}