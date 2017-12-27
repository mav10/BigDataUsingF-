#load "references.fsx"

open System
open System.IO
open FSharp.Data
open FsPlot.Highcharts.Charting

let dataPath = __SOURCE_DIRECTORY__ + "fsharp_2013-2014.csv"

type Tweets = CsvProvider<dataPath>
let tweets = Tweets.GetSample()