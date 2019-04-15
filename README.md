## О проекте
Запрос на поиск фирм:
```python
if ((~propertiesCandidate & firm.GetUndesirableProperties()) == firm.GetUndesirableProperties() &&
                    (firm.GetDesiredProperties() & propertiesCandidate) == firm.GetDesiredProperties())
```
[Просмотреть](https://github.com/Limfips/WPF_SevenLab/blob/master/WPF_SevenLab/CandidatesAndFirms/Firms.cs)

Запрос на поиск работников:
```python
if ((desiredProperties & candidate.GetPropertiesCandidate()) == desiredProperties &&
                    (propertiesFirm & candidate.GetPropertiesFirm()) == candidate.GetPropertiesFirm() &&
                    (~candidate.GetPropertiesCandidate() & undesirableProperties) == undesirableProperties)
```
[Просмотреть](https://github.com/Limfips/WPF_SevenLab/blob/master/WPF_SevenLab/CandidatesAndFirms/Candidates.cs)