import codecs
import datetime
import random


#########################################################################################
CONDITION_PER_PATIENT_LIMIT = [1, 5]

LIST_OF_CONDITION = [x for x in range(1, 21)]

DATE_LIMITS = [1970, 2020]
#########################################################################################


surnames = open("nazwiska.txt", "r")
s = surnames.readlines()
s = [x[:-1] for x in s]

names = open("imiona.txt", "r")
n = names.readlines()
n = [x[:-1] for x in n]

g = ['Male', 'Female']

pisarz_pliku_tekstowego = codecs.open("../../Resources/database.xml", "w", "utf-8")

text = '<?xml version="1.0" encoding="utf-8"?>\n' \
       '<PatientsList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">\n' \
       '\t<Patients>\n'



xdd = int(input("podaj ile chcesz miec pacjentow w bazie danych: "))

for x in range(1, xdd+1):
    name = random.choice(n) + ' ' + random.choice(s)
    sex = random.choice(g)
    pesel = random.randint(10000000000, 99999999999)
    text += '\t\t<Patient>\n' \
         '\t\t\t<Id>' + str(x) +'</Id>\n' \
         '\t\t\t<Name>' + name + '</Name>\n' \
         '\t\t\t<Sex>' + sex + '</Sex>\n' \
         '\t\t\t<Pesel>' + str(pesel) + '</Pesel>\n' \
         '\t\t\t<Conditions>\n'
    size = random.randint(CONDITION_PER_PATIENT_LIMIT[0], CONDITION_PER_PATIENT_LIMIT[1])    
    list_conditions = random.sample(LIST_OF_CONDITION, size)
    list_conditions.sort()
    iter(list_conditions)
    for element in list_conditions:
        date = datetime.date(random.randint(DATE_LIMITS[0], DATE_LIMITS[1]), random.randint(1,12),random.randint(1,28))
        text += '\t\t\t\t<Condition>\n' \
             '\t\t\t\t\t<Type>' + str(element) + '</Type>\n' \
             '\t\t\t\t\t<DiagnosisDate>' + str(date) + 'T00:00:00</DiagnosisDate>\n' \
             '\t\t\t\t</Condition>\n'
        
    text += '\t\t\t</Conditions>\n' \
         '\t\t</Patient>\n'    
    
text += '\t</Patients>\n' \
     '</PatientsList>'

pisarz_pliku_tekstowego.write(text)
pisarz_pliku_tekstowego.close()
names.close()
surnames.close()

print(text)
