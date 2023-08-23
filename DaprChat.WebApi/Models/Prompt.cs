public class Prompt {
    public string? Content { get; set; }

    public Prompt() {
        this.Content = String.Empty;
    }

    public Prompt(string content) {
        this.Content = content;
    }
}