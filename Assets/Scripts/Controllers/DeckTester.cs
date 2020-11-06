using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    //Deck<Card> _testDeck = new Deck<Card>();
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    //[SerializeField] AbilityCardView _abilityCardView = null;
    [SerializeField] GameObject _toSpawn;
    [SerializeField] Transform _pHSlotOne = null;
    [SerializeField] Transform _pHSlotTwo = null;
    [SerializeField] Transform _pHSlotThree = null;
    [SerializeField] Transform _pHSlotFour = null;
    [SerializeField] Transform _pHSlotFive = null;
    protected GameObject _phCardOne;
    protected GameObject _phCardTwo;
    protected GameObject _phCardThree;
    protected GameObject _phCardFour;
    protected GameObject _phCardFive;
    public bool phOne = false;
    public bool phTwo = false;
    public bool phThree = false;
    public bool phFour = false;
    public bool phFive = false;

    public Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    public Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    public Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    void Start()
    {
        SetUpAbilityDeck();
    }

    private void SetUpAbilityDeck()
    {
        Debug.Log("Creating Ability cards...");

        foreach (AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }
        _abilityDeck.Shuffle();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    private void Draw()
    {
        if (_playerHand.Count < 5)
        {
            AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
            Debug.Log("Drew card: " + newCard.Name);
            _playerHand.Add(newCard, DeckPosition.Top);
            if (phOne == false)
            {
                Debug.Log("Worked");
                _phCardOne = Instantiate(_toSpawn, _pHSlotOne.position, Quaternion.identity);
                AbilityCardView abilityCardView = _phCardOne.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                abilityCardView.Display(newCard);
                phOne = true;
            }
            else if (phTwo == false)
            {
                _phCardTwo = Instantiate(_toSpawn, _pHSlotTwo.position, Quaternion.identity);
                AbilityCardView abilityCardView = _phCardTwo.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                abilityCardView.Display(newCard);
                phTwo = true;
            }
            else if (phThree == false)
            {
                _phCardThree = Instantiate(_toSpawn, _pHSlotThree.position, Quaternion.identity);
                AbilityCardView abilityCardView = _phCardThree.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                abilityCardView.Display(newCard);
                phThree = true;
            }
            else if (phFour == false)
            {
                _phCardFour = Instantiate(_toSpawn, _pHSlotFour.position, Quaternion.identity);
                AbilityCardView abilityCardView = _phCardFour.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                abilityCardView.Display(newCard);
                phFour = true;
            }
            else if (phFive == false)
            {
                _phCardFive = Instantiate(_toSpawn, _pHSlotFive.position, Quaternion.identity);
                AbilityCardView abilityCardView = _phCardFive.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                abilityCardView.Display(newCard);
                phFive = true;
            }
        }
        else 
        {
            Debug.Log("Max Hand Size");
        }
        

        
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);


        Destroy(_phCardOne);
        //SortHand(); TODO
    }

    public void PlayCardOne()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);


        Destroy(_phCardOne);
    }

    public void PlayCardTwo()
    {
        AbilityCard targetCard = _playerHand.SecondItem;
        targetCard.Play();
        //TODO consider expanding remove to accept a deck position
        _playerHand.Remove(_playerHand.Count );
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);


        Destroy(_phCardTwo);
    }

    private void SortHand()
    {
        if (phOne == true)
        {
            Destroy(_phCardOne);
            if (phFive == true)
            {
                _phCardFive.transform.position = _pHSlotFour.position;

            }
            if (phTwo == true)
            {
                _phCardTwo.transform.position = _pHSlotOne.position;
                _phCardOne = _phCardTwo;
            }
        }
        else if (phTwo == true)
        {
            Destroy(_phCardTwo);
        }
        else if (phThree == true)
        {
            Destroy(_phCardThree);
        }
        else if (phFour == true)
        {
            Destroy(_phCardFour);
        }
        else if (phFive == true)
        {
            Destroy(_phCardFive);
        }
        else { }
    }

    public void TestMePlease()
    {
        Debug.Log("Yo YO YOOOOO!");
    }


}
