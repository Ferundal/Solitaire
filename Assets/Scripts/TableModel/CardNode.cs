public class CardNode
{
    public CardModel card;
    public CardNode child;
    public CardNode parent;

    public CardNode()
    {
        this.card = null;
        this.child = null;
        this.parent = null;
    }
    public CardNode(Card card)
    {
        this.card = new CardModel (card);
        this.child = null;
        this.parent = null;
    }

    public void AddChild(Card card)
    {

    }
    public void AddParents(int parentsAmount)
    {
        CardNode currentCardModel = this;
        for (; parentsAmount > 0; --parentsAmount)
        {
            currentCardModel.parent = new CardNode();
            currentCardModel = currentCardModel.parent;
        }
    }

    public int GetParentsAmount()
    {
        int parentsAmount = 0;
        CardNode currentCardNode = this;
        while (currentCardNode.parent != null)
        {
            ++parentsAmount;
            currentCardNode = currentCardNode.parent;
        }
        return parentsAmount;
    }
}
