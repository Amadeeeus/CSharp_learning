namespace My_Comparer;

public class StudentNameComparer:IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if(x == null) return (y == null) ? 0: -1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}
