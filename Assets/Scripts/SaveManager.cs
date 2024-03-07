using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using System;

public static class SaveManager
{
    private static string path = Application.persistentDataPath + "/save.dat";
    private static List<int> record= new List<int>();

    public static void SaveRecord(int pooints)
    {
        if (record.Count<6 || pooints > record[4])
        {
            reorganizarLista(pooints);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            
            List<RecordData> f= new List<RecordData>();
            foreach (int i in record)
            {
                f.Add(new RecordData(i));
            }
            formatter.Serialize(stream, f);
            stream.Close();
        }
    }

    public static List<int> LoadRecord()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
           List<RecordData> data = formatter.Deserialize(stream) as List<RecordData>;  // equivalent to (RecordData)formatter.Deserialize(stream);
            
            stream.Close();
            record.Clear();
            foreach (RecordData i in data)
            {
                record.Add(i.GetRecord());
            }
        } else
        {
            record.Clear();
        }
        return record;
    }
    private static void reorganizarLista(int num)
    {
        
            record.Add(num);
            if (record.Count > 0)
            {
                int[] r = record.ToArray();
                Array.Sort(r, (x, y) => y.CompareTo(x));
                record= r.ToList();
            if(record.Count > 5)
            {
                record.RemoveAt(5);
            }
                
                
            }
        
        
    }
    }

