using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deck <T> where T : Card
{
    List<T> _cards = new List<T>();

    public event Action Emptied = delegate { };
    public event Action<T> CardAdded = delegate { };
    public event Action<T> CardRemoved = delegate { };

    public int Count => _cards.Count;
    public T TopItem => _cards[_cards.Count - 1];
    public T SndItem => _cards[_cards.Count - 2];
    public T ThrItem => _cards[_cards.Count - 3];
    public T FrItem => _cards[_cards.Count - 4];
    public T FthItem => _cards[_cards.Count - 5];
    public T FirstItem => _cards[0];
    public T SecondItem => _cards[1];
    public T ThirdItem => _cards[2];
    public T FourthItem => _cards[3];
    public T FifthItem => _cards[4];
    public T BottomItem => _cards[0];
    public bool IsEmpty => _cards.Count == 0;
    public int FirstIndex = 0;
    /*{
        get
        {
            if (_cards.Count == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }*/
    public int SecondIndex = 1;
    public int ThirdIndex = 2;
    public int FourthIndex = 3;
    public int FifthIndex = 4;

      
    public int LastIndex
    {
        get
        {
            if (_cards.Count == 0)
            {
                return 0;
            }
            else 
            {
                return _cards.Count - 1;
            }
        }
    }


    private int GetIndexFromPosition(DeckPosition position)
    {
        int newPositionIndex = 0;

        if (_cards.Count == 0)
        {
            newPositionIndex = 0;
        }

        if (position == DeckPosition.Top)
        {
            newPositionIndex = LastIndex;
        }
        else if (position == DeckPosition.Second)
        {
            newPositionIndex = LastIndex - 1;
        }
        else if (position == DeckPosition.Third)
        {
            newPositionIndex = LastIndex - 2;
        }
        else if (position == DeckPosition.Forth)
        {
            newPositionIndex = LastIndex - 3;
        }
        else if (position == DeckPosition.Fifth)
        {
            newPositionIndex = LastIndex - 4;
        }
        else if (position == DeckPosition.Middle)
        {
            newPositionIndex = UnityEngine.Random.Range(0, LastIndex);
        }
        else if (position == DeckPosition.Bottom)
        {
            newPositionIndex = 0;
        }

        return newPositionIndex;
    }

    public void Add(T card, DeckPosition position = DeckPosition.Top)
    {
        if (card == null) { return; }

        int targetIndex = GetIndexFromPosition(position);

        if (targetIndex == LastIndex)
        {
            _cards.Add(card);
        }
        else 
        {
            _cards.Insert(targetIndex, card);
        }
        CardAdded?.Invoke(card);
    }

    public void Add(List<T> cards, DeckPosition position = DeckPosition.Top)
    {
        int itemCount = cards.Count;
        for (int i = 0; i < itemCount; i++)
        {
            Add(cards[i], position); 
        }
    }

    public T Draw(DeckPosition position = DeckPosition.Top)
    {
        if (IsEmpty)
        {
            Debug.Log("Deck: Deck is empty!");
            return default;  
        }

        int targetIndex = GetIndexFromPosition(position);

        T cardToRemove = _cards[targetIndex];
        Remove(targetIndex);

        return cardToRemove;
    }

    public void Remove(int index)
    {
        if (IsEmpty)
        {
            Debug.LogWarning("Deck: Deck is empty!");
            return;
        }
        else if (!IsIndexWithinListRange(index))
        {
            Debug.LogWarning("Deck: Nothing to remove; index out of range");
            return;
        }

        T removedItem = _cards[index];
        _cards.RemoveAt(index);

        CardRemoved?.Invoke(removedItem);

        if (_cards.Count == 0)
        {
            Emptied?.Invoke();
        }

        //Debug.Log("Deck: Removed" + removedItem.ToString());
    }

    public void RemoveSecond(DeckPosition position = DeckPosition.Second)
    {
        int targetIndex = GetIndexFromPosition(position);
        Remove(targetIndex);
    }

    public void RemoveThird(DeckPosition position = DeckPosition.Third)
    {
        int targetIndex = GetIndexFromPosition(position);
        Remove(targetIndex);
    }

    public void RemoveFourth(DeckPosition position = DeckPosition.Forth)
    {
        int targetIndex = GetIndexFromPosition(position);
        Remove(targetIndex);
    }

    public void RemoveFifth(DeckPosition position = DeckPosition.Fifth)
    {
        int targetIndex = GetIndexFromPosition(position);
        Remove(targetIndex);
    }

    bool IsIndexWithinListRange(int index)
    {
        if (index >= 0 && index <= _cards.Count - 1)
        {
            return true;
        }

        Debug.LogWarning("Deck: index outside of range; " + "index: " + index);
        return false;
    
    }

    public T GetCard(int index)
    {
        if (_cards[index] != null)
        {
            return _cards[index];
        }
        else 
        {
            return default;
        }
    }

    public void Shuffle()
    {
        for (int currentIndex = Count - 1; currentIndex > 0; --currentIndex)
        {
            int randomIndex = UnityEngine.Random.Range(0, currentIndex + 1);
            T randomCard = _cards[randomIndex];
            _cards[randomIndex] = _cards[currentIndex];
            _cards[currentIndex] = randomCard;
        }
    }
}
