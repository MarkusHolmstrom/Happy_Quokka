using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factory
{
    class IItem
    {
        public GameObject ItemGO { get; set; }
        public Component Script { get; set; }
    }


    abstract class IGameFactory
    {
        public enum Item { Cloud, Enemy }
        public abstract IItem CreateItem(Item item, GameObject go);

    }

    class CloudObject : IItem
    {
        public float Speed { get; set; }
    }

    class EnemyObject : IItem
    {
        public float Health { get; set; }
    }

    abstract class GameFactory : IGameFactory
    {
        // Start is called before the first frame update
        void Start()
        {

        }

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
