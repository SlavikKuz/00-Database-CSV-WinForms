$(function () {
    'use strict';

    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    };

    var mode = 'index';
    var intersect = true;

    var $visitorsChart = $('#visitors-chart');
    var visitorsChart = new Chart($visitorsChart, {
        data: {
            labels: ['@Model.ChartView.RangeYThisWeek[0]',
                '@Model.ChartView.RangeYThisWeek[1]',
                '@Model.ChartView.RangeYThisWeek[2]',
                '@Model.ChartView.RangeYThisWeek[3]',
                '@Model.ChartView.RangeYThisWeek[4]',
                '@Model.ChartView.RangeYThisWeek[5]',
                '@Model.ChartView.RangeYThisWeek[6]'],
            datasets: [{
                type: 'line',
                data: [
                        @Model.ChartView.ChartPointsThisWeek[0].Value,
                        @Model.ChartView.ChartPointsThisWeek[1].Value,
                        @Model.ChartView.ChartPointsThisWeek[2].Value,
                        @Model.ChartView.ChartPointsThisWeek[3].Value,
                        @Model.ChartView.ChartPointsThisWeek[4].Value,
                        @Model.ChartView.ChartPointsThisWeek[5].Value,
                        @Model.ChartView.ChartPointsThisWeek[6].Value
                    ],
    backgroundColor: 'transparent',
        borderColor: '#007bff',
            pointBorderColor: '#007bff',
                pointBackgroundColor: '#007bff',
                    fill: false
},
    {
        type: 'line',
        data: [
                        @Model.ChartView.ChartPointsLastWeek[0].Value,
                        @Model.ChartView.ChartPointsLastWeek[1].Value,
                        @Model.ChartView.ChartPointsLastWeek[2].Value,
                        @Model.ChartView.ChartPointsLastWeek[3].Value,
                        @Model.ChartView.ChartPointsLastWeek[4].Value,
                        @Model.ChartView.ChartPointsLastWeek[5].Value,
                        @Model.ChartView.ChartPointsLastWeek[6].Value
                    ],
backgroundColor: 'tansparent',
    borderColor: '#ced4da',
        pointBorderColor: '#ced4da',
            pointBackgroundColor: '#ced4da',
                fill: false
                }]
            },
options: {
    maintainAspectRatio: false,
        tooltips: {
        mode: mode,
            intersect: intersect
    },
    hover: {
        mode: mode,
            intersect: intersect
    },
    legend: {
        display: false
    },
    scales: {
        yAxes: [{
            gridLines: {
                display: true,
                lineWidth: '4px',
                color: 'rgba(0, 0, 0, .2)',
                zeroLineColor: 'transparent'
            },
            ticks: $.extend({
                beginAtZero: true,
                suggestedMax: @Model.ChartView.RangeX
    }, ticksStyle)
}],
xAxes: [{
    display: true,
    gridLines: {
        display: false
    },
    ticks: ticksStyle
}]
                }
            }
        });
    });