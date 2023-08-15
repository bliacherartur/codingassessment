using System.IO;

// Obtaining names from "unsorted-names-list.txt" and putting them into an array
string nameList = File.ReadAllText("unsorted-names-list.txt");

// Split and place each line in the text into array elements
string[] names = splitNames(nameList);

/*
   Reverses the order of the names for sorting by last name, then reverses
   once more to return to firstname lastname format. If two people share a
   last name, the Array.Sort() function will proceed down the list of names
   and sort by the remaining names.
*/
names = reverseNameOrder(names);
Array.Sort(names);
names = reverseNameOrder(names);

// Prints each name to console
foreach (string name in names) Console.WriteLine(name);

// Writes the sorted names list to "sorted-names-list.txt"
string sortedNames = String.Join("\n", names);
File.WriteAllText("sorted-names-list.txt", sortedNames);


/*
	UNIT TESTS
*/

// Read text from three test files
string testList1 = File.ReadAllText("testList1.txt");
string testList2 = File.ReadAllText("testList2.txt");
string testList3 = File.ReadAllText("testList3.txt");

// Names within test files separated into array elements
string[] testNames1 = splitNames(testList1);
string[] testNames2 = splitNames(testList2);
string[] testNames3 = splitNames(testList3);

// Reversed, sorted, reversed again
testNames1 = reverseNameOrder(testNames1);
testNames2 = reverseNameOrder(testNames2);
testNames3 = reverseNameOrder(testNames3);
Array.Sort(testNames1);
Array.Sort(testNames2);
Array.Sort(testNames3);
testNames1 = reverseNameOrder(testNames1);
testNames2 = reverseNameOrder(testNames2);
testNames3 = reverseNameOrder(testNames3);

/*
   Output is written to corresponding .txt files, printing
   1000 names to console is not ideal.
   To test these yourself, delete the "sortedTestList" files
   and this will create new ones with the same sorting done.
*/
string testSortedNames1 = String.Join("\n", testNames1);
File.WriteAllText("sortedTestList1.txt", testSortedNames1);
string testSortedNames2 = String.Join("\n", testNames2);
File.WriteAllText("sortedTestList2.txt", testSortedNames2);
string testSortedNames3 = String.Join("\n", testNames3);
File.WriteAllText("sortedTestList3.txt", testSortedNames3);




// Function to reverse the order of names in any given name.
string[] reverseNameOrder(string[] names) {
	string[] reversed = names;
	for (int i = 0; i < names.Length; i++) {
		string[] nameParts = names[i].Split(' ');
		Array.Reverse(nameParts);
		reversed[i] = string.Join(" ", nameParts);	
	}
	return reversed;
}

// Function to split a string of names into a string array of names
string[] splitNames(string nameList) {
	string[] names = nameList.Split(
		new string[] { Environment.NewLine },
		StringSplitOptions.None
	);
	return names;
}