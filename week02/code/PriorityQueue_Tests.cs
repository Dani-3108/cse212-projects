using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Three items with different priorities are enqueued: A (1), B (5), C (3).
    // Expected Result: Items come out from highest to lowest priority: B, then C, then A. 
    // Defect(s) Found: None found by this test. It passed, but it only checks the first dequeue,
    // and the highest-priority item (B) is in the middle of the list, so it does not expose every bug. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);
        var first = priorityQueue.Dequeue();
        Assert.AreEqual("B", first);
    }

    [TestMethod]
    // Scenario: Two items share the highest priority (X and Y, both 4); X was added first.
    // Expected Result: X comes out before Y, then Z.
    // Defect(s) Found: Two defects. (1) When two items had the same priority, the loop used ">=" so the
    // later item (Y) replaced the earlier one; ties must go to the item nearest the front (X). Fixed by using ">".
    // (2) Dequeue never removed the returned item from the list, so the same item (X) came out twice.
    // Fixed by calling _queue.RemoveAt(highPriorityIndex) after saving the va 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 4);
        priorityQueue.Enqueue("Y", 4);
        priorityQueue.Enqueue("Z", 2);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();
        var third = priorityQueue.Dequeue();

        Assert.AreEqual("X", first);
        Assert.AreEqual("Y", second);
        Assert.AreEqual("Z", third);
    }

    [TestMethod]
    // Scenario: Three items are enqueued with the highest priority at the back: P (1), Q (2), R (5).
    // Expected Result: R comes out first, because it has the highest priority.
    // Defect(s) Found: The for loop in Dequeue used "index < _queue.Count - 1", so it never checked
    // the last item in the list. When the highest-priority item (R) was at the back, Q was returned
    // instead. Fixed by changing the condition to "index < _queue.Count".
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("P", 1);
        priorityQueue.Enqueue("Q", 2);
        priorityQueue.Enqueue("R", 5);

        var first = priorityQueue.Dequeue();

        Assert.AreEqual("R", first);
    }


    [TestMethod]
    // Scenario: Dequeue is called on an empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: No defect found. Dequeue throws InvalidOperationException("The queue is empty.") when the queue has no items.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
    // Add more test cases as needed below.
}