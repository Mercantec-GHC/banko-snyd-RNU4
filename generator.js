function myFunction(elmnt) {
  console.log(elmnt.style.backgroundColor);
  if (elmnt.style.backgroundColor == "white") {
    elmnt.style.backgroundColor = "hsl(120, 100%, 75%)";
  } else {
    elmnt.style.backgroundColor = "white";
  }
}
var værdi;
var celle;
function nyfunktion(værdi, celle) {
  celle.innerHTML = værdi;
}

function gen_int(i) {
  var number = Math.floor(Math.random() * 10 + i * 10);
  while (number === 0) {
    var number = Math.floor(Math.random() * 10 + i * 10);
  }
  if (i === 8) {
    var number = Math.floor(Math.random() * 11 + 80);
  }
  if (i === 100) {
    var number = Math.ceil(Math.random() * 9);
  }
  return number;
}

function hasDuplicates(array) {
  return new Set(array).size !== array.length;
}

function generate_col(i) {
  var col = Array.from({ length: 3 }, () => gen_int(i));
  while (hasDuplicates(col) == true) {
    var col = Array.from({ length: 3 }, () => gen_int(i));
  }
  return col.sort();
}

function generate_row() {
  var row = Array.from({ length: 5 }, () => gen_int(100));
  while (hasDuplicates(row) == true) {
    var row = Array.from({ length: 5 }, () => gen_int(100));
  }
  return row.sort();
}

function contains_digits(rows) {
  var concat = rows[0].concat(rows[1], rows[2]);
  for (var i = 1; i < 9; i++) {
    if (concat.indexOf(i) === -1) {
      return false;
    }
  }

  if (concat.indexOf(9) === -1) {
    return false;
  }
  return true;
}
function generate_rows_check() {
  console.log(rows);
  var rows = new Array(generate_row(), generate_row(), generate_row());
  while (!contains_digits(rows)) {
    var rows = new Array(generate_row(), generate_row(), generate_row());
  }
  return rows;
}


var pladeindex = 0;
var stra = ""


function gen_plates(){
for (var i = 0; i< 10000; i++){
  update_plates("malthe"+i,1)
}
console.log(stra)

}
function update_plates(name,rara) {

  Math.seedrandom(name)
  for (var x2 = 1; x2 <= 3; x2++) {
    for (var x3 = 1; x3 <= 9; x3++) {
      var celle = "p1" + String(x2) + String(x3);
      document.getElementById(celle).innerHTML = "";
    }
  }
  var dict = {};
  for (var n = 1; n <= 3; n++) {
    var cols = [];
    for (var i = 0; i < 9; i++) {
      var col = generate_col(i);
      cols.push(col);
    }

    var rows_choose = generate_rows_check();

    var chosen_row;

    for (var j = 0; j < 3; j++) {
      for (var i = 0; i < rows_choose[j].length; i++) {
        var k = rows_choose[j][i];
        var celle = "p" + String(n) + String(j + 1) + String(k);
        dict[celle] = cols[k - 1][j];
      }

    }
  }

  /*
          plade_array[9] = new Plade(new int[,]
        {
            {1,20,42,51,62},
            {25,43,64,74,87},
            {14,28,39,66,76}
        },"malthe10");

  */
  if (rara != 1) return
  var index = 0
  var r = 0
  stra += "plade_array[" + pladeindex + "] = new Plade(new int[,]{"
  for (var key in dict) {
    var value = dict[key];

    if (r!=3){
    if (index == 0){
      stra+="{"
    }
    if (index !=4)
    stra+=value+","; else stra+=value;

    if (index == 4){ 
      index = -1; r++
      stra+="}"
      if (r!=3) stra+=","
    }
    index++
  
    //console.log(value)
    nyfunktion(value, document.getElementById(key));
  }
  }
  stra += '},"'+name+'");\n'
  pladeindex++
}

