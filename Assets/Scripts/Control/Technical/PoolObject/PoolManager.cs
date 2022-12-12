using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PoolManager
{
	private static PoolPart[] _pools;

	[System.Serializable]
	public struct PoolPart
	{
		public string name;
		public PoolObject prefab;
		public int count;
		public Transform objectsParent;
		public ObjectPooling ferula;
	}

	public static void Initialize(PoolPart[] newPools)
	{
		_pools = newPools;

		for (int i = 0; i < _pools.Length; i++)
		{
			if (_pools[i].prefab != null)
			{
				_pools[i].ferula = new ObjectPooling();
				_pools[i].ferula.Initialize(_pools[i].count, _pools[i].prefab, _pools[i].objectsParent);
			}
		}
	}

	public static GameObject GetObject(string name, Vector3 position, Quaternion rotation, Vector3 scale)
	{
		GameObject result = null;
		if (_pools != null)
		{
			for (int i = 0; i < _pools.Length; i++)
			{
				if (string.Compare(_pools[i].name, name) == 0)
				{
					result = _pools[i].ferula.GetObject().gameObject;
					result.transform.position = position;
					result.transform.rotation = rotation;
					result.transform.localScale = scale;
					result.SetActive(true);
					return result;
				}
			}
		}
		return result;
	}

}
