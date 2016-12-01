// Toggle Function

var username = "";
var preSurveyData = "";
var postSurveyData = "";
// First, checks if it isn't implemented yet.
if (!String.prototype.format) {
  String.prototype.format = function() {
    var args = arguments;
    return this.replace(/{(\d+)}/g, function(match, number) { 
      return typeof args[number] != 'undefined'
        ? args[number]
        : match
      ;
    });
  };
}

$('.toggle').click(function(){
  // Switches the Icon
  $(this).children('i').toggleClass('fa-pencil');
  // Switches the forms  
  $('.form').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
});

$( "#startButton" ).click(function(){
  if($("#loginName").val() == "" || $("#loginToken").val() == "" ) {
	alert("Username or token cannot be left empty");
	return;
  }
  var url = "http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/login.php?uname=" + $("#loginName").val() + "&token=" + $("#loginToken").val();
	$("#loader").show();
	$.get( url, function( data ) {
	data = JSON.parse(data);
	preSurveyData = data.PreTreatmentSurvey;
	postSurveyData = data.PostTreatmentSurvey;;
	$("#login").hide();
	$("#loader").hide();
	$("#progress").css({ opacity: 1 });
	$("#buttonsdiv").show();
	username = $("#loginName").val();
});
});

$( "#registerButton" ).click(function(){ 
  if($("#registerButtonInput").val() == "") {
	alert("Username cannot be left empty");
	return;
  }
  var url = "http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/registerUser.php?uname=" + $("#registerButtonInput").val();
  $("#loader").show();
  $.get( url, function( data ) {
  if(data === "Username already exists") {
	alert("Username already exists. Please Enter a different user name");
	return;
  }
  else {
	alert("Registration successful :). Please login to continue");
	$('.toggle').click();
  }
});
});


$( "#showData" ).click(function(){
  if($(".progressdiv").css("opacity") === "0") {
	  $("#login").hide();
	  $("#loader").hide();
	  $(".progressdiv").css({ opacity: 1 });
	  $(".progressdiv").show();
	  $(".survey").hide();
	  plotDataForUser(1, username);
	  plotDataForUser(2, username);
	  plotDataForUser(3, username);
	  plotDataForUser(4, username);
	  plotDataForUser(5, username);
  }
  if( $(".progressdiv").is(':visible') === false ) {
	  $("#login").hide();
	  $("#loader").hide();
	  $(".progressdiv").css({ opacity: 1 });
	  $(".progressdiv").show();
	  $(".survey").hide();
  }
});

function fillSurveyWithValues(data) {
	var answers = data.split("|");
	for(idx in answers) {
		console.log(answers[idx]);
		if(answers[idx] === "0")
			$("#No"+idx).click();
		else
			$("#Yes"+idx).click();
	}
}

$( "#postsurvey" ).click(function(){
	  var url = "http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/getQuestions.php";
	  $("#loader").show();
	  $.get( url, function( data ) {
		  $(".progressdiv").hide();
		  var questions = data.split("|");
		  var html = "<div><table>";
		  for(idx in questions) {
			html += '<tr><td style="width:700px;"><span style="float:left;">' + questions[idx] + '</span></td><td><input type="radio" id="Yes' + idx + '" name="name' + idx + '"><label>Yes</label><input type="radio" id="No' + idx + '" name="name' + idx + '"><label>No</label></td></tr>';
		  }
		  html += "</table></div>"
		  if(!postSurveyData)
			html += '<div class="buttonsdiv" style="text-align: center;margin: 10px;"><button id="submitSurvey" >Submit Response</button></div>'; 
		  $("#loader").hide();
		  $(".survey" ).append(html);
		  if(postSurveyData)
			fillSurveyWithValues(postSurveyData);
		  $("#login").hide();
	  });
});

$( "#presurvey" ).click(function(){
	  var url = "http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/getQuestions.php";
	  $("#loader").show();
	  $.get( url, function( data ) {
		  $(".progressdiv").hide();
		  var questions = data.split("|");
		  var html = "<div><table>";
		  for(idx in questions) {
			html += '<tr><td style="width:700px;"><span style="float:left;">' + questions[idx] + '</span></td><td><input type="radio" id="Yes' + idx + '" name="name' + idx + '"><label>Yes</label><input type="radio" id="No' + idx + '" name="name' + idx + '"><label>No</label></td></tr>';
		  }
		  html += "</table></div>"
		  if(!preSurveyData)
			html +=  '<div class="buttonsdiv" style="text-align: center;margin: 10px;"><button id="submitSurvey" >Submit Response</button></div>'; 
		  $("#loader").hide();
		  $(".survey" ).append(html);
		  if(preSurveyData)
			fillSurveyWithValues(preSurveyData);
		  $("#login").hide();
	  });
});

function plotDataForUser(level, uname) {
	Plotly.d3.csv('http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/getUserDataForLevel.php?level=' + level + '&uname=' + uname, function(rows){
		var trace = {
		  type: 'scatter',                    // set the chart type
		  mode: 'lines',                      // connect points with lines
		  x: rows.map(function(row){          // set the x-data
			return row['Date'];
		  }),
		  y: rows.map(function(row){          // set the x-data
			return row['TimeSpent'];
		  }),
		  line: {                             // set the width of the line.
			width: 1
		  },
		};
		var layout = {
		  title: 'Level ' + level,
		  yaxis: {title: "Time Spent"},       // set the y axis title
		  xaxis: {
			showgrid: false,                  // remove the x-axis grid lines
			tickformat: "%B, %Y"              // customize the date format to "month, day"
		  },
		};
		Plotly.plot(document.getElementById('level' + level), [trace], layout, {showLink: false});
	});
}