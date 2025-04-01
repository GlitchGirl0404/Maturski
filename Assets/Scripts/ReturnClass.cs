using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class ReturnClass
{
    public int razdaljina;
    public List<int> put;
    public ReturnClass(int razdaljina, List<int> put)
    {
        this.razdaljina = razdaljina;
        this.put = new List<int>();
        for (int i = 0; i < put.Count; i++)
        {
            this.put.Add(put[i]);
        }
    }
}