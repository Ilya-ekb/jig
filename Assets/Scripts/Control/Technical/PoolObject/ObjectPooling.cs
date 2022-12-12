using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Pool/ObjectPooling")]
public class ObjectPooling
{

	#region Data
	private List<PoolObject> _objects;
	private Transform _objectsParent;
	#endregion

	#region Interface
	public void Initialize(int count, PoolObject sample, Transform objects_parent)
	{
		_objects = new List<PoolObject>();
		_objectsParent = objects_parent;
		for (int i = 0; i < count; i++)
		{
			AddObject(sample, objects_parent);
		}
	}


	public PoolObject GetObject()
	{
		for (int i = 0; i < _objects.Count; i++)
		{
			if (_objects[i].gameObject.activeInHierarchy == false)
			{
				return _objects[i];
			}
		}
		AddObject(_objects[0], _objectsParent);
		return _objects[_objects.Count - 1];
	}
	#endregion

	#region Methods
	void AddObject(PoolObject sample, Transform objects_parent)
	{
		GameObject temp;
		temp = GameObject.Instantiate(sample.gameObject);
		temp.name = sample.name;
		temp.transform.SetParent(objects_parent);
		_objects.Add(temp.GetComponent<PoolObject>());
		if (temp.GetComponent<Animator>())
			temp.GetComponent<Animator>().StartPlayback();
		temp.SetActive(false);
	}
	#endregion

}
