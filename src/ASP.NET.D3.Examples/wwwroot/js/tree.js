// ************** Generate the tree diagram	 *****************
var svg = d3.select("svg"),
    width = +svg.attr("width"),
    height = +svg.attr("height"),
    g = svg.append("g").attr("transform", "translate(60,0)");

var tree = d3.cluster()
    .size([height, width - 160]);

var root = d3.hierarchy(treeData[0]);
tree(root);

var update = function () {
    var link = g.selectAll(".link")
        .data(root.descendants().slice(1))
        .enter()
        .append("path")
        .attr("class", "link")
        .attr("d",
            function (d) {
                return "M" +
                    d.y +
                    "," +
                    d.x +
                    "C" +
                    (d.parent.y + 100) +
                    "," +
                    d.x +
                    " " +
                    (d.parent.y + 100) +
                    "," +
                    d.parent.x +
                    " " +
                    d.parent.y +
                    "," +
                    d.parent.x;
            });

    var node = g.selectAll(".node")
        .data(root.descendants())
        .enter()
        .append("g")
        .attr("class", function (d) { return "node" + (d.children ? " node--internal" : " node--leaf"); })
        .attr("transform",
            function (d) {
                return "translate(" + d.y + "," + d.x + ")";
            });

    node.append("circle")
        .attr("r", 10);

    node.append("text")
        .attr("x", 20)
        .attr("y", 25)
        .style("text-anchor", function (d) { return d.children ? "end" : "start"; })
        .text(function (d) {
            return d.data.name;
        })
        .on("click", function (d) { openModal(d.data); });
};
update();