using UnityEngine;
using System.Collections;
using LuaInterface;
using LuaFramework;

public class LuaComponent : MonoBehaviour
{
    public LuaTable table;

    public static LuaTable Add(GameObject go, LuaTable tableClass)
    {
        LuaFunction fun = tableClass.GetLuaFunction("New");
        if (fun == null)
        {
            return null;
        }
        fun.Call(tableClass);
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.table = tableClass;
        cmp.CallAwake();
        return cmp.table;
    }

    public static LuaTable Get(GameObject go, LuaTable table)
    {
        LuaComponent[] cmps = go.GetComponents<LuaComponent>();
        foreach (LuaComponent cmp in cmps)
        {
            string mat1 = table.ToString();
            string mat2 = cmp.table.GetMetaTable().ToString();
            if (mat1 == mat2)
            {
                return cmp.table;
            }
        }
        return null;
    }

    void CallAwake()
    {
        LuaFunction fun = table.GetLuaFunction("Awake");
        if (fun != null)
        {
            fun.Call(table, gameObject);
        }
    }

    void Start()
    {
        LuaFunction fun = table.GetLuaFunction("Start");
        if (fun != null)
        {
            fun.Call(table, gameObject);
        }
    }

    void Update()
    {
        LuaFunction fun = table.GetLuaFunction("Update");
        if (fun != null)
        {
            fun.Call(table, gameObject);
        }
    }
}
