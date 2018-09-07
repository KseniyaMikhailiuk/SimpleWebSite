function InitCards(cardLimit, repeatLimit) {
    document.getElementById("initialPage").style.display='none';

    var images = GetImageArray(cardLimit, repeatLimit);
   
    var i = 0;
    var rootDir = document.getElementById("cards");
    rootDir.appendChild(CreateScore());
    var theCardLine = document.createElement("div");
    while (i < cardLimit){
        if (i % 6 == 0){
            theCardLine = document.createElement("div");
            theCardLine.className = "theCardLine";
            rootDir.appendChild(theCardLine);
        }
        theCardLine.appendChild(CreateCard(images, i));
        i++;
    }
}

function CreateScore(){
    var score = document.createElement('div');
    score.id = "score";
    score.innerText = "Score: 3";
    return score;
}

function CreateCard(images, i){

    var theCardContainer = document.createElement("div");
    theCardContainer.className = "theCardContainer";

    var theCardDiv = document.createElement("div");
    theCardDiv.className = "theCard";

    var theFrontDiv = document.createElement("div");
    theFrontDiv.className = "theFront";
    var srcImage = GetRandomImg(images);
    theFrontDiv.innerHTML = `<img src="../Content/Images/Game/${srcImage}">`;

    var theBackDiv = document.createElement("div");
    theBackDiv.className = "theBack";

    var theCardId = document.createElement("div");
    theCardId.id = `id${i}`;
    theCardId.style.width = "100%"; theCardId.style.height = "100%"; theCardId.style.position = "absolute";
    theCardId.addEventListener("click", function(){FlipCard(this);});

    theCardDiv.appendChild(theFrontDiv);
    theCardDiv.appendChild(theBackDiv);
    theCardDiv.appendChild(theCardId);
    theCardContainer.appendChild(theCardDiv);

    return theCardContainer;
}

function GetImageArray(cardLimit, repeatLimit){
    var images = [];
    var i = 1;
    var commonAmount = 0;
    while (i <= cardLimit && commonAmount < cardLimit){
        var randomRepeatAmount = (Math.floor(Math.random() * repeatLimit) + 1) * 2;
        while (randomRepeatAmount + commonAmount > cardLimit){
            randomRepeatAmount -= 2;
        }
        images.push({src:`${i}.png`, limit:randomRepeatAmount});
        commonAmount += randomRepeatAmount;
        i++;
    }
    return images;
}

function GetRandomImg(images){
    var length = images.length;
    var randomCard = Math.floor(Math.random() * length);
    while (images[randomCard].limit <= 0){
        randomCard = Math.floor(Math.random() * length);
    }
    images[randomCard].limit--;
    return images[randomCard].src;
}

var FlipedCards = {amount: 0, firstCardId: null, secondCardId: null};
var Score = 3;

function TurnCards(){
    FlipedCards.firstCardId.style.transform = "initial";
    FlipedCards.firstCardId = null;
    FlipedCards.secondCardId.style.transform = "initial";
    FlipedCards.secondCardId= null; 
}

function FlipCard(card){
    var theCard = card.parentNode;
    theCard.style.transform = "rotateY(180deg)";
    switch (FlipedCards.amount){
        case 0: 
            if (FlipedCards.firstCardId != null && FlipedCards.secondCardId != null){
                if (IsEql()){
                    Score += 3;
                }
                else{
                    TurnCards();
                    Score -= 1
                }
            }
            document.getElementById('score').innerText = `Score: ${Score}`;
            FlipedCards.firstCardId = theCard;
            FlipedCards.amount++;
            break;
        case 1:
            FlipedCards.secondCardId = theCard;
            FlipedCards.amount = 0;
            break;
        default:
            alert ("error");
            break;
    } 
    
}

function IsEql(){
    var firstCardImg = FlipedCards.firstCardId.getElementsByTagName('img')[0].src;
    var secondCardImg = FlipedCards.secondCardId.getElementsByTagName('img')[0].src;
    return firstCardImg == secondCardImg;
}

