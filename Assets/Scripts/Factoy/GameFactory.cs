using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    public class IItem
    {
        public GameObject ItemGO { get; set; }
    }

    public abstract class IGameFactory
    {
        public enum Item { Cloud, Enemy }
        public abstract IItem CreateItem(Item item, GameObject go);

    }
    // Just gave these two classes a value each for fun, but they dont do anything:
    class CloudObject : IItem
    {
        public float Speed { get; set; }
    }

    class EnemyObject : IItem
    {
        public float Health { get; set; }
    }

    public class GameFactory : IGameFactory
    {
        // Gets called from MapCreator (enemies) and CloudManager (clouds):
        public override IItem CreateItem(Item item, GameObject go)
        {
            IItem newItem = new IItem();
            switch (item)
            {
                case Item.Cloud:
                    CloudObject cloud = new CloudObject
                    {
                        ItemGO = go,
                        Speed = Random.Range(0.1f, 5f)
                    };
                    return cloud;
                case Item.Enemy:
                    EnemyObject enemyObject = new EnemyObject
                    {
                        ItemGO = go,
                        Health = 5f
                    };
                    return enemyObject;
                default:
                    break;
            }
            return newItem;
        }
    }
}
