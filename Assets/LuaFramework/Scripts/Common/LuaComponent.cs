using LuaInterface;
using UnityEngine;

public class LuaComponent : MonoBehaviour
{
    private LuaTable table;

    private LuaFunction funcAwake;
    private LuaFunction funcStart;
    private LuaFunction funcUpdate;

    [SerializeField]
    private string tableName;

    public static LuaTable Add(GameObject go, LuaTable tableClass)
    {
        LuaFunction func = tableClass.GetLuaFunction("New");
        if (func == null)
        {
            return null;
        }
        
        LuaComponent cmp = go.AddComponent<LuaComponent>();
        cmp.table = func.Invoke<LuaTable, LuaTable>(tableClass);

        cmp.funcAwake = tableClass.GetLuaFunction("Awake");
        cmp.funcStart = tableClass.GetLuaFunction("Start");
        cmp.funcUpdate = tableClass.GetLuaFunction("Update");

        string name = cmp.table.GetStringField("tableName");
        if (name != null)
        {
            cmp.tableName = name;
        }
 
        cmp.CallAwake();

        return cmp.table;
    }

    public static LuaTable Get(GameObject go, LuaTable table)
    {
        LuaComponent[] cmps = go.GetComponents<LuaComponent>();
        for (int i = 0; i < cmps.Length; i++)
        {
            if (table == cmps[i].table.GetMetaTable())
            {
                return cmps[i].table;
            }
        }
        return null;
    }

    void CallAwake()
    {
        if (funcAwake != null)
        {
            funcAwake.Call(table, gameObject);
        }
    }

    void Start()
    {
        if (funcStart != null)
        {
            funcStart.Call(table, gameObject);
        }
    }

    void Update()
    {
        if (funcUpdate != null)
        {
            funcUpdate.Call(table);
        }
    }
}
