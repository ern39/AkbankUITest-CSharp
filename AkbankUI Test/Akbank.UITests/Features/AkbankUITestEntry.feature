Feature: AkbankUITestEntry
Akbank adresine gidilir ve kredi ödeme planı detayları izlenir


Scenario: AkbankUITestScenario
    * Enter Akbank Home Page 'https://akbank.com/'
	* Scroll down to the bottom of the page
	* Click on Kredi Hesaplama
	* Enter '50000' tl in Tutar field
	* Choose SİGORTASIZ
	* Set vade as '20AY'
	* Click Hesaplama Detayları
	* Check Masraf ve Maliyet Oranları is opened
	* Click Ödeme Planı
	* Check Ödeme Planı is opened
	* Scroll down on the Ödeme Planı page until 20th is seen