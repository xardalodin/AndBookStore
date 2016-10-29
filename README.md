# AndBookStore
Code test bookstore Xamarin Android

just testing the 60% reusing of code Xamarin promises. 

Ok so it uses almost exactly the same backendcode as the windows bookstore project. 
the only thing that dident work was the javascriptserialzer.
so used json.Net instead installed it trough nuget. works the same.

UITOOLS worked the same.

THE Android UI construcion is about 1000% slower than windows form construction.
mostly becouse of lag.

note:
going trough a youtube xamarin turtorial.
https://www.youtube.com/watch?v=tf2O_t-ayJ8&list=PLCuRg51-gw5VqYchUekCqxUS9hEZkDf6l&index=6
did 8. then built this.
going to continue.

Problems: 
the install .. VS2015 wants to install jdk7 when jdk8 is the one needed??
so control panel , programs and features , find vs2015 klick change
wait
then klick modify and add xamarin.

Debug/Window/exeptions settings ->  click in all the "Commen Language Runtime exceptions" 
Or you will somtimes get errors but no row highlighted in code . just somthings wrong but no clue what.
