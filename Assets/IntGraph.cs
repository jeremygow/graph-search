using UnityEngine;
using System.Collections.Generic;

public interface IntGraph {
	bool addNode(int a);                 // true if node added
	bool addEdge(int a, int b, int c);  // true if edge added
	List<int> nodes();
	List<int> neighbours(int a);
	int cost(int a, int b);    // -1 if no edge
}


class AdjListGraph : IntGraph {
	
	protected Dictionary<int, Dictionary<int, int>> adjLists;
	
	public AdjListGraph() {
		adjLists = new Dictionary<int, Dictionary<int, int>> ();
	}

	public bool hasNode(int a) {
		return adjLists.ContainsKey(a);
	}

	// Add a new node
	public bool addNode(int a) {
		
		if (a > -1 && !hasNode(a)) {
			// Add the node with empty edge dictionary
			adjLists[a] = new Dictionary<int,int>();
			return true;
		} else {
			// Node already exists or negative index
			return false;
		}
	}
	
	// Add the edge a->b
	public bool addEdge(int a, int b, int c) {

		// Check nodes exist but edge doesn't
		if (hasNode (a) && hasNode (b) && !adjLists [a].ContainsKey (b)) {
			// Add new edge
			adjLists [a] [b] = c;
			return true;
				
		} else {
			return false;
		}
	}
	
	// List all the nodes
	public List<int> nodes() {
		return new List<int>(adjLists.Keys);
	}
	
	// List the neighbour nodes for a given node
	public List<int> neighbours(int a) {
		return new List<int>(adjLists[a].Keys);
	}
	
	// The cost for edge a->b
	public int cost(int a, int b) {
		return adjLists[a][b];
	}
}