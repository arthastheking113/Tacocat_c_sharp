// function for running
function reverseTheString(str) {
  // Reverse our string
  return str.split("").reverse().join("");
}

function clearword(){
  document.getElementById("word").value = "";
  document.getElementById("mirror").placeholder = "Mirror";
  document.getElementById("mirror").value = "";
  document.getElementById("result").placeholder = "Result";
}
// Let the user know whether it's a palindrome



// Mirror what we type

let reversedString = []; // Have somewhere to store keypresses

// Get the input box and add an event listener
document.getElementById("word").addEventListener("keydown", (event) => {
  if (
    event.key !== "Backspace" &&
    event.key !== "Enter" &&
    event.key !== "Tab" &&
    event.key !== "Shift" &&
    !event.altKey &&
    !event.ctrlKey
  ) {
    // Last in first out
    reversedString.unshift(event.key);
    
  }
  if (event.key == "Backspace") {
    // Remove first element of the array if we hit backspace
    reversedString.shift();
  }

  // Add an if to check the input - if it's empty, reset reversed string.

  if (reversedString.length < 1) {
    // If there's nothing in the input box replace the placeholder
    document.getElementById("mirror").placeholder = "Mirror";
    reversedString = [];
  } else {
    // Otherwise, spit out whatever is in the array
    document.getElementById("mirror").placeholder = reversedString.join("");
  }
  // REFACTOR THIS SO THAT WE GET OUR MIRROR FROM OUR INPUT BOX AND NOT THE KEYS
  document.getElementById("clearword").addEventListener("click", (event) => {
      reversedString = []
      document.getElementById("word").value = "";
      document.getElementById("mirror").placeholder = "Mirror";
      document.getElementById("mirror").value = "";
      document.getElementById("result").placeholder = "Result";
  })
  
});
