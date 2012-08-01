using System;
using System.Collections.Generic;
using System.Collections;

namespace VitaUnit
{
	internal class TestResults : IDictionary<string,List<TestResult>>
	{
		private readonly Dictionary<string,List<TestResult>> _testResults = new Dictionary<string, List<TestResult>>();
		
		public TestResults() {
		}
		
		public void Add(KeyValuePair<string, List<TestResult>> item) {
			_testResults.Add(item.Key, item.Value);
		}
		
		public void Add(string key, List<TestResult> value) {
			_testResults.Add(key, value);
		}
		
		public void AddRange(TestResults sourceResults) {
			foreach(string key in sourceResults.Keys) {
				Add(key, sourceResults[key]);
			}
		}
		
		public void Clear() {
			_testResults.Clear();
		}
		
		public bool Contains(KeyValuePair<string, List<TestResult>> item) {
			return _testResults.ContainsKey(item.Key) && _testResults[item.Key].Equals(item.Value);
		}
		
		public bool ContainsKey(string key) {
			return _testResults.ContainsKey(key);
		}
		
		public void CopyTo(KeyValuePair<string, List<TestResult>>[] array, int arrayIndex) {
			throw new NotImplementedException();
		}
		
		public int Count {
			get {
				return _testResults.Count;
			}
		}
		
		public IEnumerator<KeyValuePair<string, List<TestResult>>> GetEnumerator() {
			return _testResults.GetEnumerator();
		}
		
		IEnumerator IEnumerable.GetEnumerator() {
			return _testResults.GetEnumerator();
		}
		
		public bool IsReadOnly {
			get {
				return false;
			}
		}
		
		public List<TestResult> this[string key] {
			get {
				if(!_testResults.ContainsKey(key)) {
					_testResults[key] = new List<TestResult>();
				}
				return _testResults[key];
			}
			set {
				_testResults[key] = value;
			}
		}
		
		public ICollection<string> Keys {
			get {
				return _testResults.Keys;
			}
		}
		
		public bool Remove(KeyValuePair<string, List<TestResult>> item) {
			return Remove(item.Key);
		}
		
		public bool Remove(string key) {
			return _testResults.Remove(key);
		}
		
		public bool TryGetValue(string key, out List<TestResult> value) {
			return _testResults.TryGetValue(key, out value);
		}
		
		public ICollection<List<TestResult>> Values {
			get {
				return _testResults.Values;
			}
		}
	}
}

