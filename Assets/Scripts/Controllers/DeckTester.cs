using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    //Deck<Card> _testDeck = new Deck<Card>();
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] GameObject _discardZone = null;
    //[SerializeField] AbilityCardView _abilityCardView = null;
    [SerializeField] GameObject _toSpawn = null;
    [SerializeField] Transform _pHSlotOne = null;
    [SerializeField] Transform _pHSlotTwo = null;
    [SerializeField] Transform _pHSlotThree = null;
    [SerializeField] Transform _pHSlotFour = null;
    [SerializeField] Transform _pHSlotFive = null;
    [SerializeField] GameObject _buttonOne = null;
    [SerializeField] GameObject _buttonTwo = null;
    [SerializeField] GameObject _buttonThree = null;
    [SerializeField] GameObject _buttonFour = null;
    [SerializeField] GameObject _buttonFive = null;
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
    public float _discardCount = 0;

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
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }*/
    }

    public void Draw()
    {
        if (_abilityDeck.IsEmpty == false)
        {
            if (_playerHand.Count < 5)
            {
                AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
                Debug.Log("Drew card: " + newCard.Name);
                _playerHand.Add(newCard, DeckPosition.Top); //Changed top to bottom
                if (phOne == false)
                {
                    _phCardOne = Instantiate(_toSpawn, _pHSlotOne.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardOne.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phOne = true;
                    _pHSlotOne.gameObject.SetActive(true);

                }
                else if (phTwo == false)
                {
                    _phCardTwo = Instantiate(_toSpawn, _pHSlotTwo.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardTwo.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phTwo = true;
                    _pHSlotTwo.gameObject.SetActive(true);

                }
                else if (phThree == false)
                {
                    _phCardThree = Instantiate(_toSpawn, _pHSlotThree.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardThree.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phThree = true;
                    _pHSlotThree.gameObject.SetActive(true);

                }
                else if (phFour == false)
                {
                    _phCardFour = Instantiate(_toSpawn, _pHSlotFour.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFour.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phFour = true;
                    _pHSlotFour.gameObject.SetActive(true);

                }
                else if (phFive == false)
                {
                    _phCardFive = Instantiate(_toSpawn, _pHSlotFive.position, Quaternion.identity);
                    AbilityCardView abilityCardView = _phCardFive.transform.Find("Canvas").transform.Find("Panel").GetComponent<AbilityCardView>();
                    abilityCardView.Display(newCard);
                    phFive = true;
                    _pHSlotFive.gameObject.SetActive(true);

                }
            }
            else
            {
                Debug.Log("Max Hand Size");
            }
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
        AbilityCard targetCard = _playerHand.FirstItem;
        targetCard.Play();
        //TODO consider expanding remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        //Destroy(_phCardOne);
        phOne = false;
        _pHSlotOne.gameObject.SetActive(false);
        PlayCardOnBoard(_phCardOne);
    }

    public void PlayCardTwo()
    {
        AbilityCard targetCard = _playerHand.SecondItem;
        targetCard.Play();
        //_playerHand.Remove(_playerHand.FirstIndex);
        _playerHand.RemoveSecond(DeckPosition.Second);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        phTwo = false;
        _pHSlotTwo.gameObject.SetActive(false);
        PlayCardOnBoard(_phCardTwo);
    }

    public void PlayCardThree()
    {
        AbilityCard targetCard = _playerHand.ThirdItem;
        targetCard.Play();
        _playerHand.RemoveThird(DeckPosition.Third);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        phThree = false;
        _pHSlotThree.gameObject.SetActive(false);
        PlayCardOnBoard(_phCardThree);
    }

    public void PlayCardFour()
    {
        AbilityCard targetCard = _playerHand.FourthItem;
        targetCard.Play();
        _playerHand.RemoveFourth(DeckPosition.Forth);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        phFour = false;
        _pHSlotFour.gameObject.SetActive(false);
        PlayCardOnBoard(_phCardFour);
    }

    public void PlayCardFive()
    {
        AbilityCard targetCard = _playerHand.FifthItem;
        targetCard.Play();
        _playerHand.RemoveFifth(DeckPosition.Fifth);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
        phFive = false;
        _pHSlotFive.gameObject.SetActive(false);
        PlayCardOnBoard(_phCardFive);
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

    public void SetUpHand()
    {
        for (int i = 0; i < 5; i++)
        {
            Draw();
        }
    }

    public void SwitchButtonsOn()
    { 
        _buttonOne.SetActive(true);
        _buttonTwo.SetActive(true);
        _buttonThree.SetActive(true);
        _buttonFour.SetActive(true);
        _buttonFive.SetActive(true);
    }

    public void SwitchButtonsOff()
    {
        _buttonOne.SetActive(false);
        _buttonTwo.SetActive(false);
        _buttonThree.SetActive(false);
        _buttonFour.SetActive(false);
        _buttonFive.SetActive(false);
    }

    public void PlayCardOnBoard(GameObject slot)
    {

        //slot.transform.position = _discardZone.transform.position;
        slot.transform.Rotate(90, 0, 0, Space.World);
        slot.transform.position = new Vector3(_discardZone.transform.position.x, _discardZone.transform.position.y + _discardCount, _discardZone.transform.position.z);
        _discardCount += .01f;
    }
}
