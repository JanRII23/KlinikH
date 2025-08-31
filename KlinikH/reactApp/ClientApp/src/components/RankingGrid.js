const RankingGrid = ({ items, imgArr }) => {

    const rankingGrid = [];
    const cellCollectionTop = [];
    const cellCollectionMiddle = [];
    const cellCollectionBottom = [];
    const cellCollectionWorst = [];

    function pushCellMarkupToArr(cellCollection, rankNum, rowLabel) {

    }

    function createCellsForRows(rowNum) {
        var rankNum = 0;
        var currCollection = [];
        var label = "";
        const numCells = 5;

        for (var a = 1; a <= numCells; a++) {
            rankNum = (a === 1) ? 0 : (numCells * (rowNum - 1)) + a - rowNum;

            if (rowNum === 1) {
                currCollection = cellCollectionTop;
                label = "Top Tier";
            } else if (rowNum === 2) {
                currCollection = cellCollectionMiddle;
                label = "Middle Tier";
            } else if (rowNum === 3) {
                currCollection = cellCollectionBottom;
                label = "Bottom Tier"
            } else if (rowNum === 4) {
                currCollection = cellCollectionWorst;
                label = "Worst Tier";
            }
            pushCellMarkupToArr(currCollection, rankNum, label);
        }
    }

    function createCellsForRows() {
        const maxRows = 4;
        for (var row = 1; row <= maxRows; row++) {
            createCellsForRows(row);
        }
    }

    function createRowsForGrid() {
        rankingGrid.push(<div className="rank-row top-tier">{cellCollectionTop}</div>);
        rankingGrid.push(<div className="rank-row middle-tier">{cellCollectionMiddle}</div>);
        rankingGrid.push(<div className="rank-row bottom-tier">{cellCollectionBottom}</div>);
        rankingGrid.push(<div className="rank-row worst-tier">{cellCollectionWorst}</div>);

        return rankingGrid;
    }

    function createRankingGrid() {
        createCellsForRows();
        return createRowsForGrid();
    }

    return (
        <div className = "rankings">
            {createRankingGrid()}
        </div>
    )

}

export default RankingGrid