using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlchemyDialog_Behavior : MonoBehaviour {
    public AlchemyDialog Alchemy_Dialog;
    private void Start()
    {
        Alchemy_Dialog.Node1Original = Alchemy_Dialog.node[1].NPC_Text;
    }
    public void StartDialog()
    {
        Alchemy_Dialog.startDialog();
    }
}

[System.Serializable]
public class AlchemyDialog : NPCDialog
{
    //[HideInInspector]
    public string Node1Original;
    public override void startDialog()
    {
        FillItemsInNode();
        //node[3].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        //node[3].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        //node[3].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[3].reply[0].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Кристалл", ref i);
            ItemInAlchemyCase.Items[0] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Кристалл");
            FillItemsInNode();
        });
        node[3].reply[1].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Корень", ref i);
            ItemInAlchemyCase.Items[0] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Корень");
            FillItemsInNode();
        });
        node[3].reply[2].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Язык Икабоса", ref i);
            ItemInAlchemyCase.Items[0] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Язык Икабоса");
            FillItemsInNode();
        });
        node[3].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[0] != null)
            {
                ItemInAlchemyCase.Items[0].AddItem();
                ItemInAlchemyCase.Items[0] = null;
            }
            FillItemsInNode();
        });


        //node[4].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        //node[4].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        //node[4].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[4].reply[0].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Кристалл", ref i);
            ItemInAlchemyCase.Items[1] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Кристалл");
            FillItemsInNode();
        });
        node[4].reply[1].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Корень", ref i);
            ItemInAlchemyCase.Items[1] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Корень");
            FillItemsInNode();
        });
        node[4].reply[2].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Язык Икабоса", ref i);
            ItemInAlchemyCase.Items[1] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Язык Икабоса");
            FillItemsInNode();
        });
        node[4].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[1] != null)
            {
                ItemInAlchemyCase.Items[1].AddItem();
                ItemInAlchemyCase.Items[1] = null;
                FillItemsInNode();
            }

        });


        //node[5].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        //node[5].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        //node[5].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[5].reply[0].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Кристалл", ref i);
            ItemInAlchemyCase.Items[2] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Кристалл");
            FillItemsInNode();
        });
        node[5].reply[1].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Корень", ref i);
            ItemInAlchemyCase.Items[2] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Корень");
            FillItemsInNode();
        });
        node[5].reply[2].OnReplyEvent.AddListener(delegate
        {
            int i = 0;
            Inventory.FindItemWithName("Язык Икабоса", ref i);
            ItemInAlchemyCase.Items[2] = Inventory._inventory[i].ConstractItem();
            Inventory.DeleteItemWithName("Язык Икабоса");
            FillItemsInNode();
        });
        node[5].reply[3].OnReplyEvent.AddListener(delegate
        {
            if (ItemInAlchemyCase.Items[2] != null)
            {
                ItemInAlchemyCase.Items[2].AddItem();
                ItemInAlchemyCase.Items[2] = null;
                FillItemsInNode();
            }

        });
        base.startDialog();
    }
    public void FillItemsInNode()
    {
        node[1].NPC_Text = Node1Original;
        for (int i = 0; i < 3; i++)
        {
            int StartIndex = 0;
            for (int j = 0; j < i + 1; j++)
            {
                StartIndex = node[1].NPC_Text.IndexOf("[", StartIndex + 1);
            }
            if (ItemInAlchemyCase.Items[i] == null)
            {
                node[1].NPC_Text = node[1].NPC_Text.Insert(StartIndex + 1, "Ничего").ToString();
                Debug.Log("Insert Nothing");
            }
            else
            {
                node[1].NPC_Text = node[1].NPC_Text.Insert(StartIndex + 1, ItemInAlchemyCase.Items[i].name);
                Debug.Log("Insert Item");
            }
        }
    }
    public override void putNode()
    {
        node[3].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[3].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[3].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[4].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[4].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[4].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");

        node[5].reply[0].ShoudBeShowen = Inventory.FindItemWithName("Кристалл");
        node[5].reply[1].ShoudBeShowen = Inventory.FindItemWithName("Корень");
        node[5].reply[2].ShoudBeShowen = Inventory.FindItemWithName("Язык Икабоса");
        base.putNode();
    }
}