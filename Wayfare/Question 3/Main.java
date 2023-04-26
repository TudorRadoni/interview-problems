import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Map<String, Integer> stock = new HashMap<>();

        try (Scanner scanner = new Scanner(System.in)) {
            String line;
            while (!(line = scanner.nextLine()).isEmpty()) {
                // Parse string into barcode and quantity
                String[] parts = line.split(",");
                String barcode = parts[0].trim();
                int quantity = Integer.parseInt(parts[1].trim());

                // Set the value of the barcode to the current value + the quantity
                // If the barcode is not in the map, the current value is 0
                stock.put(barcode, stock.getOrDefault(barcode, 0) + quantity);
            }
        } catch (NumberFormatException e) {
            e.printStackTrace();
        }
        
        // Sort the entries by value
        List<Map.Entry<String, Integer>> entries = new ArrayList<>(stock.entrySet());
        Collections.sort(entries, (e1, e2) -> e2.getValue().compareTo(e1.getValue()));

        // Print the entries
        for (Map.Entry<String, Integer> entry : entries) {
            System.out.println(entry.getKey() + ", " + entry.getValue());
        }
    }
}
