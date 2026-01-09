public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        bool contains = false;

        if (value == Data)
        {
            contains = true;
        }
        else if (value < Data)
        {
            bool? doesContain = Left?.Contains(value);
            if (doesContain == true)
            {
                contains = true;
            }
            else
            {
                contains = false;
            }
        }
        else
        {
            bool? doesContain = Right?.Contains(value);
            if (doesContain == true)
            {
                contains = true;
            }
            else
            {
                contains = false;
            }
        }

        // TODO Start Problem 2
        return contains;
    }

    public int GetHeight()
    {
        int totalLeftHeight = 0;
        int totalRightHeight = 0;

        if (Left != null)
        {
            totalLeftHeight = Left?.GetHeight() ?? 0;
        }
        if (Right != null)
        {
            totalRightHeight = Right?.GetHeight() ?? 0;
        }



        // TODO Start Problem 4
        return 1 + System.Math.Max(totalLeftHeight, totalRightHeight);
    }
}