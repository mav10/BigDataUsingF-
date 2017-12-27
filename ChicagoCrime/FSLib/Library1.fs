
module FSAnalysis

#light
open System
open FSharp.Data
open FSharp.Charting
open FSharp.Charting.ChartTypes
open System.Drawing
open System.Windows.Forms

//
// Parse one line of CSV data:
//
//   Date,IUCR,Arrest,Domestic,Beat,District,Ward,Community,Year
//   09/03/2015 11:57:00 PM,0820,true,false,0835,008,18,66,2015
//   ...
//
// Returns back a tuple with most of the information:
//
//   (date, iucr, arrested, domestic, community, year)
//
// as string*string*bool*bool*int*int.
//
let private ParseOneCrime (line : string) = 
  let elements = line.Split(',')
  let date = elements.[0]
  let iucr = elements.[1]
  let arrested = Convert.ToBoolean(elements.[2])
  let domestic = Convert.ToBoolean(elements.[3])
  let community = Convert.ToInt32(elements.[elements.Length - 2])
  let year = Convert.ToInt32(elements.[elements.Length - 1])
  (date, iucr, arrested, domestic, community, year)

let private ParseOneTweet (line : string) = 
    let elements = line.Split(',')
    let createdDate = elements.[0]
    let fromUserScreenName = elements.[1]
    let text = elements.[2]
    let tweetId = elements.[3]
    let source = elements.[4]
    let language = elements.[5]
    (createdDate,fromUserScreenName,text,tweetId,source,language)
// 
// Parse file of crime data, where the format of each line 
// is discussed above; returns back a list of tuples of the
// form shown above.
//
//
//  let LINES  = System.IO.File.ReadLines(filename)
//  let DATA   = Seq.skip 1 LINES
//  let CRIMES = Seq.map ParseOneCrime DATA
//  Seq.toList CRIMES
//
let private ParseCrimeData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneCrime
  |> Seq.toList

let private ParseTweets filename = 
    System.IO.File.ReadLines(filename)
    |> Seq.skip 1  // skip header row:
    |> Seq.map ParseOneCrime
    |> Seq.toList

//
// Given a list of crime tuples, returns a count of how many 
// crimes were reported for the given year:
//
let private CrimesThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> year = crimeyear) crimes
  let numCrimes = List.length crimes2
  numCrimes


//
// CrimesByYear:
//
// Given a CSV file of crime data, analyzes # of crimes by year, 
// returning a chart that can be displayed in a Windows desktop
// app:
//
let CrimesByYear(filename) = 
  //
  // debugging:  print filename, which appears in Visual Studio's Output window
  //
  printfn "Calling CrimesByYear: %A" filename
  //
  let crimes = ParseCrimeData filename
  //
  let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  //
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts
  //
  // debugging: see Visual Studio's Output window (may need to scroll up?)
  //
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear
  //
  // plot:
  //
  let myChart = 
    Chart.Line(countsByYear, Name="Total # of Crimes")
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  //
  // return back the chart for display:
  //
  myChartControl

////////////////////////// Arrest % ////////////////////////////////

// Finds the number of arrest by each year
let private ArrestsThisYear crimes crimeyear = 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> if (arrested) then year = crimeyear else false) crimes
  let numCrimes = List.length crimes2
  numCrimes


let ArrestByYear(filename) = 
  
  printfn "Calling ArrestByYear: %A" filename // debug
  
  // map total crime by year
  let crimes = ParseCrimeData filename // parse data
  let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts 
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear

  // Now map the arrests made by each year
  let counts = List.map (fun year -> ArrestsThisYear crimes year) range
  let ArrestByYear = List.map2 (fun year count -> (year, count)) range counts
  printfn "Counts: %A" counts // debug
  printfn "ArrestByYeay: %A" ArrestByYear // debug

  // plot:
  let myChart = 
    Chart.Combine([ Chart.Line(countsByYear, Name="Total # of Crimes")
                    Chart.Line(ArrestByYear, Name ="# of Arrests")
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  // return back the chart for display:
  myChartControl


//////////////////////////// By Crime Code ////////


// Parse the line in the ICUR-codes file
let private ParseOneCode (line : string) = 
  let elements = line.Split(',')
  let iucr = elements.[0]
  let primaryDesc = elements.[1]
  let secondDesc = elements.[2]
  (iucr, primaryDesc, secondDesc)

// Parse the file lines into a list
let private ParseCodeData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseOneCode
  |> Seq.toList

// Search if the code exits. If it does, return the First and Second Description. Else return unknown code found
let private searchCode numCode list = 
  let valid = List.exists (fun (iucr, primaryDesc, secondDesc) -> if (iucr = numCode) then true else false) list
  if valid = true then
    let R = List.find (fun (iucr, primaryDesc, secondDesc) -> if (iucr = numCode) then true else false) list
    let _,first,second = R
    first + ": " + second // concat both description
  else
    "unknown crime code"

// return number of crime occured each year related to provided iucr code
let private numCrimeThisYear crimes crimeyear numCrime = 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> if (iucr = numCrime) then year = crimeyear else false) crimes
  let numCrimes = List.length crimes2
  numCrimes

let numCrimeByCode (filename, crimeCode) = 
 
  printfn "Calling numCrimeByYear: %A" filename // debug
  let crimes = ParseCrimeData filename
  let IUCRcodes = ParseCodeData "IUCR-codes.csv" 
  printfn "IUCRcodes: %A" IUCRcodes // debug

  // map total crime by year
  let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts 
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear

  // map total crime by year related to provided iucr code
  let counts = List.map (fun year -> numCrimeThisYear crimes year crimeCode) range
  let numCrimeByCode = List.map2 (fun year count -> (year, count)) range counts
  printfn "Counts (Code) : %A" counts // debug
  printfn "numCrimeByCode: %A" numCrimeByCode // debug

  // Returns the name of crime code provided
  let returnCrimeName = searchCode crimeCode IUCRcodes
  printfn "Returned Community Code : %A" returnCrimeName // debug

  let myChart = 
    Chart.Combine([ Chart.Line(countsByYear, Name="Total # of Crimes")  
                    Chart.Line(numCrimeByCode, Name = returnCrimeName)
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  // return back the chart for display:
  myChartControl

////////////// By Provided Area Name ////////////////

// Parse each line in Areas.csv into tuples
let private ParseAreaCode (line : string) = 
  let elements = line.Split(',')
  let areaCode = elements.[0]
  let areaName = elements.[1]
  (areaCode, areaName)

// Parse the tuples into a list
let private ParseAreaData filename = 
  System.IO.File.ReadLines(filename)
  |> Seq.skip 1  // skip header row:
  |> Seq.map ParseAreaCode
  |> Seq.toList

// returns the community number associated with the area
let private valArea (areaString:string) list = 
  let valid = List.exists (fun (areaCode, areaName) -> if (areaName = areaString) then true else false) list
  if valid = true then
    let R = List.find (fun (areaCode, areaName) -> if (areaName = areaString) then true else false) list
    let first,_ = R
    first
  else
    "0"

// For Legend Output, returns the areaName. if not found then returns "Not Found"
let private nameArea (areaString:string) list = 
  let valid = List.exists (fun (areaCode, areaName) -> if (areaName = areaString) then true else false) list
  if valid = true then
    let R = List.find (fun (areaCode, areaName) -> if (areaName = areaString) then true else false) list
    let _,second = R
    second
  else
    "area not found"

let private numCrimeThisArea crimes crimeyear numArea = 
 if numArea <> 0 then
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> if (community = numArea) then year = crimeyear else false) crimes
  let numCrimes = List.length crimes2
  numCrimes
 else
  0

let numCrimeByArea(filename, areaString) =
  // debugging:  print filename, which appears in Visual Studio's Output window
  printfn "Calling numCrimeByYear: %A" filename
  let crimes = ParseCrimeData filename
  let areaData = ParseAreaData "Areas.csv"
  printfn "%A" areaData

  // map total crime by year
  let (_, _, _, _, _, minYear) = List.minBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let (_, _, _, _, _, maxYear) = List.maxBy (fun (date, iucr, arrested, domestic, community, year) -> year) crimes
  let range  = [minYear .. maxYear]
  let counts = List.map (fun year -> CrimesThisYear crimes year) range
  let countsByYear = List.map2 (fun year count -> (year, count)) range counts 
  printfn "Counts: %A" counts
  printfn "Counts by Year: %A" countsByYear

  // find community area code and convert String to int
  let returnCommunityCode = valArea areaString areaData
  printfn "Returned crime test : %A" returnCommunityCode
  let CodeToInt = Convert.ToInt32(returnCommunityCode) // convert string to int
  printfn "Converted Integer: %A" CodeToInt // debug

  // Now, map number of crime related to provided area
  let counts = List.map (fun year -> numCrimeThisArea crimes year CodeToInt) range
  let numCrimeByArea = List.map2 (fun year count -> (year, count)) range counts
 
  printfn "Counts (Area): %A" counts // debug
  printfn "numCrimeByYear by Area: %A" numCrimeByArea // debug
 
  // plot:
  let myChart = 
    Chart.Combine([ Chart.Line(countsByYear, Name="Total # of Crimes")
                    Chart.Line(numCrimeByArea, Name = nameArea areaString areaData)
                  ])
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  // return back the chart for display:
  myChartControl

///////// Total crimes by Chicago Area ///////////

// returns number of crimes in the area
let private ThisYear crimes numArea = 
  let crimes2 = List.filter (fun (date, iucr, arrested, domestic, community, year) -> if (community = numArea) then true else false) crimes
  let numCrimes = List.length crimes2
  numCrimes


let CrimeByArea(filename) =

  printfn "Calling CrimeByArea: %A" filename // debug
  let crimes = ParseCrimeData filename
  let codes = ParseAreaData "Areas.csv"

  // map crime relative to community code (Area)
  let range = List.map (fun (areaCode:string, areaName) -> Convert.ToInt32(areaCode)) codes
  let counts = List.map (fun area -> ThisYear crimes area) range
  let countsByCommunityCode = List.map2 (fun area count -> (area, count)) range counts

  // debugging 
  printfn "Counts: %A" counts
  printfn "Counts by Community Code: %A" countsByCommunityCode
  
  // plot:
  let myChart = 
    Chart.Line(countsByCommunityCode, Name="Total Crimes By Chicago Area")
  let myChart2 = 
    myChart.WithTitle(filename).WithLegend();
  let myChartControl = 
    new ChartControl(myChart2, Dock=DockStyle.Fill)
  // return back the chart for display:
  myChartControl
