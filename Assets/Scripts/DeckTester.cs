using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class DeckTester : MonoBehaviour
{
    //Deck<Card> _testDeck = new Deck<Card>();

    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    void Start()
    {
        SetUpAbilityDeck();

        /**/
    }

    private void SetUpAbilityDeck()
    {
        Debug.Log("Creating Ability cards...");
        AbilityCard cardA = new AbilityCard("Sword");
        _abilityDeck.Add(cardA);
        AbilityCard cardB = new AbilityCard("Shield");
        _abilityDeck.Add(cardB);
        AbilityCard cardC = new AbilityCard("Staff");
        _abilityDeck.Add(cardC);
        AbilityCard cardD = new AbilityCard("Barrier");
        _abilityDeck.Add(cardD);

        _abilityDeck.Shuffle();
        //Card testCard = _abilityDeck.Draw(DeckPosition.Top);
        //Debug.Log("Drew card: " + testCard);
        //testCard.Play();
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
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);
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
        //TODO consider expandin remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to dicard: " + targetCard.Name);
    }
}
