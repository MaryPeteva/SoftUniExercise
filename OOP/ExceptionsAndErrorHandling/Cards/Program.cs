string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
List<Card> deck = new List<Card>();
for (int i = 0; i < input.Length; i++)
{
    string[] inp = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
    try
    {
        Card temp = new Card(inp[0], inp[1]);
        deck.Add(temp);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

foreach (Card temp in deck) 
{
    Console.Write(temp.ToString());
}

public class Card
{
    private string face;
    private string suit;
    private readonly Dictionary<string, string> suits = new Dictionary<string, string> { { "S", "\u2660" }, { "H", "\u2665" }, { "D", "\u2666" }, { "C", "\u2663" } };
    private readonly List<string> faces = new List<string>{"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};

    public Card(string faceIn, string suitIn)
    {
        Face = faceIn;
        Suit = suitIn;
    }

    public string Face
    {
        get => this.face;
        private set
        {
            if (!faces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            this.face = value;
        }
    }
    public string Suit
    {
        get => this.suit;
        private set
        {
            if (!suits.ContainsKey(value)) 
            {
                throw new ArgumentException("Invalid card!");
            }
            this.suit = suits[value];

        }
    }

    public override string ToString()
    {
        return $"[{this.face}{this.suit}] ";
    }
}
