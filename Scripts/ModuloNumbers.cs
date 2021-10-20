using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ModuloNumbers
{
    public static string DisplayNumbers()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 1; i <= 100; i++)
        {
            bool isModifiedByModulo = false;
            if(i % 3 == 0)
            {
                isModifiedByModulo = true;
                sb.Append("Marko");
            }
            if (i % 5 == 0)
            {
                isModifiedByModulo = true;
                sb.Append("Polo");
            }
            if(!isModifiedByModulo)
            {
                sb.Append(i);
            }
            sb.Append(" ");
        }

        return sb.ToString();
    }
}
