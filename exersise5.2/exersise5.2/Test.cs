

class Test
{
    private string value1;
    private string value2;
    private string value3;
    public Test()
    {
        value1 = "1";
        value2 = "2";
        value3 = "3";
    }
    public string Value1
    {
        get {return value1;}
        set {this.value1 = value;}
    }
    public string Value2
    {
       get {return value2;}
       set {this.value2 = value;}
    }
    public string Value3
    {
       get {return value3;}
       set {this.value2 = value;}
    }
    public void Deconstruct(out string value11, out string value22, out string value33)
    {
        value11 = Value1;
        value22 = Value2;
        value33 = Value3;
    }
}
