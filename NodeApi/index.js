var express = require("express");
var app = express();

//CORS
app.use(function(req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
  });

app.get("/url", (req, res, next) => {
  res.json(["Tony","Lisa","Michael","Ginger","Food"]);
});

app.listen(3000, () => {
  console.log("Server running on port 3000");
});

app.get("/async", async (request, response) => {
  try {
    const result = await asyncTest();
    
    response.json([result, "tony async"]);
  }
  catch(error) {
    console.log(error.toString());
  }
 });

 app.get("/parallel", async (request, response) => {
  try {
    var parallelTest = new ParallelTest();
    const result = await parallelTest.take3subtake1part1();
    
    response.json([result, "tony async 2"]);
  }
  catch(error) {
    console.log(error.toString());
  }
 });

 async function asyncTest(){
  await new Promise(resolve => setTimeout(resolve, 1100));

  return 'async result';
}

class ParallelTest {

  // Used to watch amount of Promises executing in a single moment of time
  counter = 0;
  interval;
  // Overall amount of operations
  numberOfOperations = 25;
  // Arguments per operation
  listOfArguments = [];
  // Delays per operation to fake async request
  listOfDelays = [];

  constructor() {
    // Fill delays in order to use the same array between all invocations
    // Single delay is a value in milliseconds from 1000 to 10000
    for (let i = 0; i < this.numberOfOperations; i++) {
      this.listOfArguments.push(i);
      this.listOfDelays.push(Math.ceil(Math.random() * 9) * 1000);
    }
  }

  // Helper funtion to see the amount of running Promises each second
  // watchCounter = () => {
  //   console.log('Promises running in the beginning:', counter);

  //   if (interval) {
  //     clearInterval(interval);
  //   }

  //   interval = setInterval(() => console.log('Promises running:', counter), 1000);
  // };

  async take3subtake1part1() {
    const concurrencyLimit = 5;
    // Enhance arguments array to have an index of the argument at hand
    const argsCopy = [].concat(this.listOfArguments.map((val, ind) => ({ val, ind })));
    const result = new Array(this.listOfArguments.length);
    const promises = new Array(concurrencyLimit).fill(Promise.resolve());

    // Fake async: resolve an array through arbitrary delay
    // Increase a counter in order to watch amount of Promises executed
    const asyncOperation = index => {
      this.counter++;
      return new Promise(resolve =>
        setTimeout(() => {
          console.log('Operation performed:', index);
          this.counter--;
          resolve(index);
        }, this.listOfDelays[index]))
    };

    // Recursively chain the next Promise to the currently executed Promise
    function chainNext(p) {
      if (argsCopy.length) {
        const arg = argsCopy.shift();
        return p.then(() => {
          // Store the result into the array upon Promise completion
          const operationPromise = asyncOperation(arg.val).then(r => { result[arg.ind] = r; });
          return chainNext(operationPromise);
        });
      }
      return p;
    }
  
    await Promise.all(promises.map(chainNext));
    return result;
  };
}