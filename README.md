# Gta-Notification-System
# Unity Notification System in C#

This script defines a simple notification system in Unity for displaying messages.

## Notification Class Explanation

The `Notification` class is a MonoBehaviour that manages the creation, display, and removal of notifications.

### Serialized Fields

- **NotificationPrefab:** Reference to the prefab representing a notification. Design your notification in a GameObject and convert it into a prefab.

- **NotificationParent:** The parent GameObject under which notifications will be instantiated.

### Methods

#### `ShowNotification(string Message)`

- Entry point for showing a notification.
- Takes a string `Message` as a parameter, representing the content of the notification.

#### `CreateNotification(string Subtitle)`

- Coroutine method for creating a new notification GameObject.
- Instantiates the `NotificationPrefab` under the `NotificationParent` and adds it to a list called `SpawnNotification`.
- Iterates through the list of spawned notifications, finds the `TMP_Text` component (TextMeshPro) within each notification, and sets the text of the second text component (assuming it exists) to the provided `Subtitle`.
- Waits for 6 seconds, fades out the notifications over 1.5 seconds, waits for an additional 2 seconds, and then destroys the notification GameObjects.

## How to Use

1. **Create Notification Prefab:**
   - Create a new GameObject in your Unity scene, design it as the notification you want, and convert it into a prefab.

2. **Attach Script:**
   - Attach the `Notification` script to a GameObject in your scene.

3. **Assign Prefab and Parent:**
   - Assign the created notification prefab and the parent under which notifications will be instantiated to the `NotificationPrefab` and `NotificationParent` fields, respectively.

4. **Show Notifications:**
   - Call the `ShowNotification` method whenever you want to display a notification, providing the desired message.

   Example:

   ```csharp
   public class Example : MonoBehaviour
   {
       [SerializeField] private Notification notificationSystem;

       void Start()
       {
           notificationSystem.ShowNotification("This is a sample notification!");
       }
   }
