# Week 04 Foundation Programs Design

## Program 1: YouTube Videos (Abstraction)

### Purpose

Store information about several YouTube videos and their comments, then display each video's details, comment count, and comments. The program uses sample data; it does not connect to YouTube or request input.

### Classes and Responsibilities

| Class | Responsibility |
| --- | --- |
| `Video` | Hold a video's title, author, length in seconds, and comments. Add comments and report how many it contains. |
| `Comment` | Hold the name of the commenter and the text of one comment. |
| `Program` | Create 3-4 videos with 3-4 comments each, collect the videos, and display each video's information and comments. |

### Class Diagram

```mermaid
classDiagram
    class Video {
        -string _title
        -string _author
        -int _lengthInSeconds
        -List~Comment~ _comments
        +Video(string title, string author, int lengthInSeconds)
        +AddComment(Comment comment) void
        +GetCommentCount() int
        +GetComments() IReadOnlyList~Comment~
    }
    class Comment {
        -string _commenterName
        -string _text
        +Comment(string commenterName, string text)
        +GetCommenterName() string
        +GetText() string
    }
    class Program {
        +Main(string[] args) void
    }
    Video "1" *-- "0..*" Comment : contains
    Program ..> Video : creates and displays
```

### Program Flow

```mermaid
flowchart TD
    A[Start] --> B[Create 3-4 Video objects]
    B --> C[Create and add 3-4 Comment objects to each video]
    C --> D[Add videos to a list]
    D --> E[For each video, display title, author, and length]
    E --> F[Display GetCommentCount result]
    F --> G[Display each commenter's name and comment text]
    G --> H{More videos?}
    H -- Yes --> E
    H -- No --> I[End]
```

## Program 2: Online Ordering (Encapsulation)

### Purpose

Represent customer orders and calculate each order's total, including shipping. For each order, display a packing label listing products and a shipping label showing the customer's name and address. The program uses sample data and does not request input.

### Classes and Responsibilities

| Class | Responsibility |
| --- | --- |
| `Product` | Encapsulate a product's name, product ID, unit price, and quantity; calculate its line total. |
| `Address` | Encapsulate street, city, state/province, and country; format the address and determine whether it is in the USA. |
| `Customer` | Encapsulate the customer's name and `Address`; report whether the customer lives in the USA by asking the address. |
| `Order` | Hold one customer and a list of products; calculate product totals plus one shipping charge, and create packing and shipping labels. |
| `Program` | Create at least two orders, each with 2-3 products, and display the total and both labels for each order. |

### Class Diagram

```mermaid
classDiagram
    class Product {
        -string _name
        -string _productId
        -decimal _pricePerUnit
        -int _quantity
        +Product(string name, string productId, decimal pricePerUnit, int quantity)
        +GetName() string
        +GetProductId() string
        +GetTotalCost() decimal
    }
    class Address {
        -string _street
        -string _city
        -string _stateOrProvince
        -string _country
        +Address(string street, string city, string stateOrProvince, string country)
        +IsInUSA() bool
        +GetFullAddress() string
    }
    class Customer {
        -string _name
        -Address _address
        +Customer(string name, Address address)
        +GetName() string
        +GetAddress() Address
        +IsInUSA() bool
    }
    class Order {
        -Customer _customer
        -List~Product~ _products
        +Order(Customer customer)
        +AddProduct(Product product) void
        +GetTotalCost() decimal
        +GetPackingLabel() string
        +GetShippingLabel() string
    }
    class Program {
        +Main(string[] args) void
    }
    Customer "1" *-- "1" Address : has
    Order "1" *-- "1" Customer : ships to
    Order "1" *-- "1..*" Product : contains
    Program ..> Order : creates and displays
```

### Rules and Program Flow

- A product line total is `price per unit * quantity`.
- The order total is the sum of product line totals plus one shipping charge: `$5` when the customer's address is in the USA, otherwise `$35`.
- The packing label lists every product's name and product ID.
- The shipping label lists the customer's name and full address.
- Keep member fields private; expose only the constructors and methods needed to build orders and request their results.

```mermaid
flowchart TD
    A[Start] --> B[Create Address and Customer]
    B --> C[Create Order for customer]
    C --> D[Create and add 2-3 Products]
    D --> E[Create a second order with its customer and products]
    E --> F[For each order, calculate product costs and shipping]
    F --> G[Display total, packing label, and shipping label]
    G --> H{More orders?}
    H -- Yes --> F
    H -- No --> I[End]
```