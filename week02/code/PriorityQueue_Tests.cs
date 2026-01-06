using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with three PriorityItems of different values: Diamond (10), $5 bill (4),
    // and Lawnmower blade (6). Enqueue them in the following order: blade, diamond, dollar.
    // Ensure that the queue is in that order.
    // Expected Result: "Lawnmower blade", "Diamond", "$5 bill"
    // Defect(s) Found: None found. Everything runs properly.
    public void TestPriorityQueue_1()
    {
        var diamond = new PriorityItem("Diamond", 10);
        var dollar = new PriorityItem("$5 bill", 4);
        var blade = new PriorityItem("Lawnmower blade", 6);


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(blade.Value, blade.Priority);
        priorityQueue.Enqueue(diamond.Value, diamond.Priority);
        priorityQueue.Enqueue(dollar.Value, dollar.Priority);


        string[] expectedResult = new[] { "Lawnmower blade", "Diamond", "$5 bill" };

        int queueLength = priorityQueue.GetQueueLength();
        while (queueLength > 0)
        {
            if (queueLength > expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var items = priorityQueue.GetQueueStrings();
            CollectionAssert.AreEqual(expectedResult, items);
            queueLength--;
        }

    }

    [TestMethod]
    // Scenario: Create a queue with three PriorityItems of different values: Diamond (10), $5 bill (4),
    // and Lawnmower blade (6). Enqueue them in the following order: blade, diamond, dollar.
    // Ensure that the queue after the most valuable item is taken out removes the most valuable item.
    // Expected Result: "Lawnmower blade", "$5 bill"
    // Defect(s) Found: Dequeue does not remove the highest value PriorityItem from the queue. Fixed by
    // ensuring that it removes.
    public void TestPriorityQueue_2()
    {
        var diamond = new PriorityItem("Diamond", 10);
        var dollar = new PriorityItem("$5 bill", 4);
        var blade = new PriorityItem("Lawnmower blade", 6);


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(blade.Value, blade.Priority);
        priorityQueue.Enqueue(diamond.Value, diamond.Priority);
        priorityQueue.Enqueue(dollar.Value, dollar.Priority);

        priorityQueue.Dequeue();


        string[] expectedResult = new[] { "Lawnmower blade", "$5 bill" };

        int queueLength = priorityQueue.GetQueueLength();
        while (queueLength > 0)
        {

            var items = priorityQueue.GetQueueStrings();
            CollectionAssert.AreEqual(expectedResult, items);
            queueLength--;
        }

    }




    [TestMethod]
    // Scenario: Create a queue with PriorityItems of different values, and at two of them have the same value.
    // Enqueue each item, then run Dequeue. Compare the expected result to the highest priority item that is
    // closer to the front of the queue.
    // Expected Result: "Diamond"
    // Defect(s) The Dequeue tie breaking (>=) was wrong. It selected the item further to the back compared to the front.
    // set the tie breaking to be greater than (>) instead of (=).
    public void TestPriorityQueue_3()
    {
        var diamond = new PriorityItem("Diamond", 10);
        var dollar = new PriorityItem("$5 bill", 4);
        var blade = new PriorityItem("Lawnmower blade", 6);
        var tire = new PriorityItem("Tire", 10);
        var pumpkin = new PriorityItem("Pumpkin", 2);
        var car = new PriorityItem("Car", 9);
        var paper = new PriorityItem("Piece of Paper", 1);


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(blade.Value, blade.Priority);
        priorityQueue.Enqueue(diamond.Value, diamond.Priority);
        priorityQueue.Enqueue(tire.Value, tire.Priority);
        priorityQueue.Enqueue(dollar.Value, dollar.Priority);
        priorityQueue.Enqueue(pumpkin.Value, pumpkin.Priority);
        priorityQueue.Enqueue(car.Value, car.Priority);
        priorityQueue.Enqueue(paper.Value, paper.Priority);


        string expectedResult = "Diamond";
        var actualResult = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, actualResult);
    }
    [TestMethod]
    // Scenario: Create a queue with PriorityItems of different values, and at two of them have the same value.
    // Enqueue each item, then run Dequeue. Ensure that the highest value item can be at the back and it is still counted.
    // Expected Result: "Diamond"
    // Defect(s) In the Dequeue function, the for loop stops before the last element, meaning that the code never
    // compares the final item's priority. removed the "- 1" in the for loop.
    public void TestPriorityQueue_4()
    {
        var dollar = new PriorityItem("$5 bill", 4);
        var blade = new PriorityItem("Lawnmower blade", 6);
        var pumpkin = new PriorityItem("Pumpkin", 2);
        var car = new PriorityItem("Car", 9);
        var paper = new PriorityItem("Piece of Paper", 1);
        var diamond = new PriorityItem("Diamond", 10);


        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(blade.Value, blade.Priority);
        priorityQueue.Enqueue(dollar.Value, dollar.Priority);
        priorityQueue.Enqueue(pumpkin.Value, pumpkin.Priority);
        priorityQueue.Enqueue(car.Value, car.Priority);
        priorityQueue.Enqueue(paper.Value, paper.Priority);
        priorityQueue.Enqueue(diamond.Value, diamond.Priority);


        string expectedResult = "Diamond";
        var actualResult = priorityQueue.Dequeue();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    // Scenario: Create an instance of PriorityQueue and try to Dequeue without ever calling Enqueue. Assert a ThrowsException
    // and ensure that it is throwing the right kind of exception and that the exception says "the queue is empty."
    // Expected Result: ("") -- an empty string.
    // Defect(s) Found: None. 
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();

        var msg = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", msg.Message);

    }

}