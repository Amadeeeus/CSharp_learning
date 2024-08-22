namespace My_Comparer;

public class StudentAgeComparer:IComparer<Student>
{ 
    public int Compare(Student x, Student y)
    {
        if(x.Age < y.Age)
        {return -1;}
        else if(x.Age > y.Age)
        {return 1;}
        else
        {return 0;}
    }
}
