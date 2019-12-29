using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
    public class GameObjectPool {
		private string poolName;
        private GameObject poolObjectPrefab;
        private Stack<GameObject> availableObjStack = new Stack<GameObject>();

        public GameObjectPool(string poolName, GameObject poolObjectPrefab, int initCount) {
			this.poolName = poolName;
            this.poolObjectPrefab = poolObjectPrefab;

            for (int index = 0; index < initCount; index++) {
				AddObjectToPool(NewObjectInstance());
			}
		}

        private void AddObjectToPool(GameObject go) {
            if (go == null)
            {
                return;
            }

            if (!availableObjStack.Contains(go))
            {
                availableObjStack.Push(go);
                go.SetActive(false);
                go.transform.SetParent(LuaHelper.GetPoolManager().PoolRootObject, false);
            }
		}

        private GameObject NewObjectInstance() {
            return GameObject.Instantiate(poolObjectPrefab) as GameObject;
		}

		public GameObject NextAvailableObject() {
            GameObject go = null;
			if(availableObjStack.Count > 0) {
				go = availableObjStack.Pop();
			} else {
                //Debug.LogWarning("No object available & cannot grow pool: " + poolName);
                go = NewObjectInstance();
			}
            if (go != null)
            {
                go.SetActive(true);
            }
            return go;
		} 
		
        public void ReturnObjectToPool(string pool, GameObject po) {
            if (poolName.Equals(pool)) {
                AddObjectToPool(po);
			} else {
				Debug.LogError(string.Format("Trying to add object to incorrect pool {0} ", poolName));
			}
		}
	}
}
