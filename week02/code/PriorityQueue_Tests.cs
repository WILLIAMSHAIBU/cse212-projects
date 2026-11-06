
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: The original Dequeue method did not correctly examine all items
    // and did not remove the selected item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 2);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Charlie", 3);

        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
        Assert.AreEqual("Alice", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items with the same highest priority.
    // Expected Result: Items with equal priority are removed in FIFO order.
    // Defect(s) Found: The original Dequeue method did not correctly handle
    // equal priorities and did not remove the selected item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Alice", 5);
        priorityQueue.Enqueue("Bob", 5);
        priorityQueue.Enqueue("Charlie", 5);

        Assert.AreEqual("Alice", priorityQueue.Dequeue());
        Assert.AreEqual("Bob", priorityQueue.Dequeue());
        Assert.AreEqual("Charlie", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items in a specific order with different priorities.
    // Expected Result: Items are added to the back, and the highest priority
    // item is removed first without changing the order of other items.
    // Defect(s) Found: The original Dequeue method did not remove the selected
    // item, causing the same item to be returned repeatedly.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No defect found. The original method correctly throws
    // the required exception when the queue is empty.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
