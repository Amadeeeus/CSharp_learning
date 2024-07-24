int i;
int j = 10;
int k = 10;
int m;
int result;
for(i =1 ; i <= j; i++)
{   
    Console.WriteLine(" ");
    for(m =1; m<=k; m++)
    {
        
        result = i*m;
        Console.WriteLine("{0} * {1} = {2}",i,m,result);
    }
}
